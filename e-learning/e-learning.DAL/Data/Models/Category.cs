using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_learning.DAL.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } // for soft delete purpose to show the categories
                                            // has IsDeleted=false
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
