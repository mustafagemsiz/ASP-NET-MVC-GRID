using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_GRID.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 character."), Required]
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}