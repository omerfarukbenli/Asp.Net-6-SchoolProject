using Business.Abstract;
using Business.Constans;
using Business.ValidationRules;
using Core.Aspects.Validaiton;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Add(Lesson lesson)
        {
            //Validation Kontrol
            _lessonDal.Add(lesson);
            //Log, Cachle
            return new SuccessResult(Messages.AddedLesson);
        }

        public IResult Update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
            return new SuccessResult(Messages.UpdateLesson);
        }

        public IDataResult<Lesson> GetById(int id)
        {
            var result = _lessonDal.Get(p => p.Id == id);
            return new SuccessDataResult<Lesson>(result);
        }

        public IDataResult<List<Lesson>> GetList()
        {
            var result = _lessonDal.GetList();
            return new SuccessDataResult<List<Lesson>>(result);
        }
    }
}
