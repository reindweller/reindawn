using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReindawnApi.Models
{
    public class NewsViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
    }
}