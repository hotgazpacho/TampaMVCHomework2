using System.Collections.Generic;

namespace Homework2.Models
{
    public abstract class Entity : IEntity
    {
        public long Id { get; set; }

        public ValidationResults Validate()
        {
            return new ValidationResults(InternalValidate());
        }

        protected virtual IEnumerable<ValidationResult> InternalValidate()
        {
            var errors = Validation.Validate(GetType(), this);
            errors.AddRange(GetCustomResults());
            return errors;
        }

        protected virtual IEnumerable<ValidationResult> GetCustomResults()
        {
            return new List<ValidationResult>();
        }
    }
}