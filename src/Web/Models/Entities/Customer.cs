using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Homework2.Models
{
    public class Customer : Entity, ICustomer
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be 100 characters or less.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(200, ErrorMessage = "Email must be 200 characters or less.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Valid Email Address is required.")]
        public string Email { get; set; }
    }
}