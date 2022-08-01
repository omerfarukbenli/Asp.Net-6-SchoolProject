using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ders adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ders adı en az 3 karakter olmalıdır");
        }
    }
}
