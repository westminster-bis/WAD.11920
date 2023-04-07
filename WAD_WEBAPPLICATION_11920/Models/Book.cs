using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WAD_WEBAPPLICATION_11920.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Book Title")]
        public string BookTitle { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [DisplayName("Book Author")]
        public string Author { get; set; }

        [Required]
        [DisplayName("Issued Year")]
        public DateTime IssuedYear { get; set; }

        public int Borrower { get; set; }

        [DisplayName("Borrower Name")]
        public string BorrowerName { get; set; }


    }

}