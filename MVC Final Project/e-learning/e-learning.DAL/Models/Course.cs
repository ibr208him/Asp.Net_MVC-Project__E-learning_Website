using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_learning.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; }
        public Category Category { get; set; }


        //public int InstructorId { get; set; }
        //public Instructor Instructor { get; set; }

    }
}
