using System;
using System.ComponentModel.DataAnnotations;
namespace QuotingDojo.Models
{
    public class User{

        [Required]
        public string Name{get; set;}

        [Required]
        public string Quote{get; set;}
    }
}