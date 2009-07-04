using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Homework2.Models
{
    public class ValidationResults : IEnumerable<ValidationResult>
    {
        private readonly List<ValidationResult> _results;

        public ValidationResults(IEnumerable<ValidationResult> results)
        {
            _results = results == null ? new List<ValidationResult>() : results.ToList();
        }

        public bool IsValid
        {
            get { return _results.Count == 0; }
        }

        public static ValidationResults Valid
        {
            get { return new ValidationResults(new List<ValidationResult>()); }
        }

        #region IEnumerable<ValidationResult> Members

        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        #endregion
    }
}