using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Validations;
using FluentValidation;

namespace Core.Aspects.Validaiton
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatiorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Veri tipi hatalı");
            }
            _validatiorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatiorType);
            var entityType = _validatiorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
