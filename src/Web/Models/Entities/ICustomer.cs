using System;
namespace Homework2.Models
{
    public interface ICustomer : IEntity
    {
        string Email { get; set; }
        string Name { get; set; }
    }
}
