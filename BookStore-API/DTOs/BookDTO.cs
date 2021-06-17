﻿using System.ComponentModel.DataAnnotations;

namespace BookStore_API.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string ISBN { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? AuthorId { get; set; }
        public virtual AuthorDTO Authors { get; set; }
    }

    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; }
        public int? Year { get; set; }
        [Required]
        public string ISBN { get; set; }
        [StringLength(500)]
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public int? AuthorId { get; set; }
    }

    public class BookUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string ISBN { get; set; }
        [StringLength(500)]
        public string Summary { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public int? AuthorId { get; set; }
    }

}

