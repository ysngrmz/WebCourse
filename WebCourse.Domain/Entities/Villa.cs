using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourse.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        [Range(1, 100)]
        public int Sqft { get; set; }

         [Required(ErrorMessage = "Occupancy is Required")]
        public int Occupancy { get; set; }

        [Display(Name="Image URL Information")]
        public string? ImageUrl { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }


    }
}
