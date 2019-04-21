using Library.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
    public class Book : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
