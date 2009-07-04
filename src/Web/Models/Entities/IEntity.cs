using System;
namespace Homework2.Models
{
    public interface IEntity
    {
        long Id { get; set; }
        ValidationResults Validate();
    }
}
