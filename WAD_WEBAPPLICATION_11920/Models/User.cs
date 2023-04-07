using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WAD_WEBAPPLICATION_11920.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(6)]
        public string FirstName { get; set; }

        [Required, StringLength(6)]
        public string LastName { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}