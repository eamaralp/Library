﻿using System;

namespace Library.Domain.Dto
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
