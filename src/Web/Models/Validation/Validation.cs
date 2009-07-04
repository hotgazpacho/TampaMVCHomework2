using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Homework2.Models
{
    public class Validation
    {
        public static List<ValidationResult> Validate(Type type, Entity entity)
        {
            var validationInstance = new Validation();
            return validationInstance.ValidateAttributesInternal(type, entity);
        }


        public virtual List<ValidationResult> ValidateAttributesInternal(Type type, Entity entity)
        {
            var validationIssues = new List<ValidationResult>();

            // Get list of properties from validationModel
            PropertyInfo[] props = type.GetProperties();

            // Perform validation on each property
            foreach (PropertyInfo prop in props)
                ValidateProperty(validationIssues, entity, prop);

            return validationIssues;
        }


        protected virtual void ValidateProperty<TEntity>(List<ValidationResult> validationIssues, TEntity entity,
                                                         PropertyInfo property)
        {
            object[] validators = property.GetCustomAttributes(typeof (ValidationAttribute), true);
            foreach (ValidationAttribute validator in validators)
                ValidateValidator(validationIssues, entity, property, validator);
        }

        protected virtual void ValidateValidator<TEntity>(List<ValidationResult> validationIssues, TEntity entity,
                                                          PropertyInfo property, ValidationAttribute validator)
        {
            object value = property.GetValue(entity, null);
            if (!validator.IsValid(value))
            {
                validationIssues.Add(new ValidationResult(property.Name, validator.ErrorMessage));
            }
        }
    }
}