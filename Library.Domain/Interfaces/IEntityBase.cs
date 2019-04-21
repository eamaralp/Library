using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Interfaces
{
    public interface IEntityBase
    {
        [Key]
        Guid Id { get; set; }
    }
}
