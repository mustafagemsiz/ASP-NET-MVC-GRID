using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_GRID.Models
{
    [Table("Users")]
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50,ErrorMessage ="Maximum 50 character."),Required]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 character."), Required]
        public string Surname { get; set; }
        public int Age { get; set; }

        public Country Country { get; set; }
    }
}