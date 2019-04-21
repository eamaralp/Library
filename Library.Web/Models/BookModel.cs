using System;

namespace Library.Web.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
