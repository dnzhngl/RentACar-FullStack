using CarRental.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CarRental.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Core.Aspects.Autofac.Validation
{
    /// <summary>
    /// Responsible for the validation of entities that are sent as a parameter.
    /// Type of validator must be given.
    /// Example usage : [ValidationAspect(typeof(CustomValidator))]
    /// </summary>
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        /// <summary>
        /// Checks the given class whether it is a type of "IValidator" or not. 
        /// Throws an exception if the type of given class is not a validator.
        /// </summary>
        /// <param name="validatorType"></param>
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir." /*AspectMessages.WrongValidationType*/);
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
