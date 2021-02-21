using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HttpClientDemo.Stuff
{
    public class Book
    {
        public Book(string title,string author)
        {
            this.Author = author;
            this.Title = title;
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
    }
}
