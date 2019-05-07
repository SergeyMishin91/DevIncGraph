using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIncGraph.Models
{
    public class UserData
    {
        public int UserDataId { get; set; }

        [Required(ErrorMessage = "Please, enter a value")]
        public int RangeFrom { get; set; }

        [Required(ErrorMessage = "Please, enter a value")]
        public int RangeTo { get; set; }

        [Required(ErrorMessage = "Please, enter a value")]
        [Range(0,100)]
        public float Step { get; set; }

        [Required(ErrorMessage = "Please, enter a value")]
        public int A { get; set; }

        [Required(ErrorMessage = "Please, enter a value")]
        public int B { get; set; }

        [Required(ErrorMessage = "Please, enter a value")]
        public int C { get; set; }

        public ICollection<Point> Points { get; set; }

        public UserData()
        {
            Points = new List<Point>();
        }
    }
}
