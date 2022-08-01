using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;
        private readonly IFileService _fileService;

        public TeacherManager(ITeacherDal teacherDal, IFileService fileService)
        {
            _teacherDal = teacherDal;
            _fileService = fileService;
        }

        public IResult Add(TeacherRegisterDto registerDto)
        {
            IResult result = BusinessRules.Run(
            CheckTeacherIdentityNumberExists(registerDto.IdentityNumber),
            CheckIfFileTypeAllowed(registerDto.Image.FileName),
            CheckIfFileSizeAllowed(registerDto.Image.Length)
            );

            if (result != null)
            {
                return result;
            }

            string fileName = _fileService.SaveFileToServer(registerDto.Image, @"C:\Youtube\SchoolFrontEndProject\src\assets\img\Teachers\");
            //string fileName = _fileService.SaveFileToFtp(registerDto.Image);
            //byte[] fileByte = _fileService.GetFileBinaryType(registerDto.Image); 

            var teacher = CreateTeacherEntity(registerDto, fileName);

            _teacherDal.Add(teacher);

            return new SuccessResult("Öğretmen kaydı başarıyla tamamlandı");
        }

        public IDataResult<List<Teacher>> GetList()
        {
            var results = _teacherDal.GetList();
            return new SuccessDataResult<List<Teacher>>(results);
        }

        public IResult CheckIfFileTypeAllowed(string fileName)
        {
            var fileType = fileName.Substring(fileName.IndexOf('.'));
            fileType = fileType.ToLower();
            List<string> AllowFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
            if (!AllowFileExtensions.Contains(fileType))
            {
                return new ErrorResult("Eklediğiniz resim .jpeg .jpg .gif .png türlerinden biri olmalıdır!");
            }
            return new SuccessResult();
        }

        public Teacher CreateTeacherEntity(TeacherRegisterDto registerDto, string fileName)
        {
            byte[] paswordHash, paswordSalt;
            HashingHelper.CreatePasswordHash("1", out paswordHash, out paswordSalt);
            Teacher teacher = new Teacher()
            {
                Gender = registerDto.Gender,
                Address = registerDto.Address,
                Id = 0,
                IdentityNumber = registerDto.IdentityNumber,
                IsActive = true,
                Name = registerDto.Name,
                PaswordHash = paswordHash,
                PaswordSalt = paswordSalt,
                ImageUrl = fileName
            };
            return teacher;
        }

        public IResult CheckIfFileSizeAllowed(long fileSize)
        {
            decimal imgMbSize = Convert.ToDecimal(fileSize * 0.000001);
            if (imgMbSize > 1)
            {
                return new ErrorResult("Yüklediğiniz resim boyutu en fazla 1Mb olabilir!");
            }
            return new SuccessResult();
        }

        public IResult CheckTeacherIdentityNumberExists(string identityNumber)
        {
            var result = _teacherDal.GetList(p => p.IdentityNumber == identityNumber);
            if (result.Count() > 0)
            {
                return new ErrorResult("Bu TC daha önce kullanılmış");
            }
            return new SuccessResult();
        }


        public IResult Update(TeacherRegisterDto teacherRegisterDto)
        {
            var teacher = _teacherDal.Get(p => p.Id == teacherRegisterDto.Id);

            if (teacher.IdentityNumber != teacherRegisterDto.IdentityNumber)
            {
                IResult result = BusinessRules.Run(
                CheckTeacherIdentityNumberExists(teacherRegisterDto.IdentityNumber)
                );

                if (result != null)
                {
                    return result;
                }
            }

            string fileName = "";

            if (teacherRegisterDto.Image != null)
            {
                IResult result = BusinessRules.Run(
                CheckIfFileTypeAllowed(teacherRegisterDto.Image.FileName),
                CheckIfFileSizeAllowed(teacherRegisterDto.Image.Length)
                );

                if (result != null)
                {
                    return result;
                }

                fileName = _fileService.SaveFileToServer(teacherRegisterDto.Image, @"C:\Youtube\SchoolFrontEndProject\src\assets\img\Teachers\");
            }
            else
            {
                fileName = teacher.ImageUrl;
            }

            var teacherEntity = CreateTeacherEntityForUpdate(teacherRegisterDto, fileName, teacher);

            _teacherDal.Update(teacherEntity);

            return new SuccessResult("Öğretmen kaydı başarıyla güncellendi");
        }

        public Teacher CreateTeacherEntityForUpdate(TeacherRegisterDto registerDto, string fileName, Teacher teacher)
        {
            Teacher teacherEntity = new Teacher()
            {
                Gender = registerDto.Gender,
                Address = registerDto.Address,
                Id = Convert.ToInt16(registerDto.Id),
                IdentityNumber = registerDto.IdentityNumber,
                IsActive = teacher.IsActive,
                Name = registerDto.Name,
                PaswordHash = teacher.PaswordHash,
                PaswordSalt = teacher.PaswordSalt,
                ImageUrl = fileName
            };
            return teacherEntity;
        }

        public IDataResult<Teacher> GetById(int id)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(p => p.Id == id));
        }
    }
}
