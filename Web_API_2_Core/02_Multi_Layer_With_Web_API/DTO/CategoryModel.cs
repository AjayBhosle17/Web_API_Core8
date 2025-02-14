using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Name Is Required")]
        [MinLength(2,ErrorMessage ="Plz Enter minimum 2 charcters")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Order Is Required")]
        [Range(1,500,ErrorMessage ="Order Should be Between 1 and 500")]
        public int Order { get; set; }

    }
}
