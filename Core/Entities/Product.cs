using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("MyProducts",Schema ="Base")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(120),Required]
        public string ProductName { get; set; }
        public long Price { get; set; }
    }
}
