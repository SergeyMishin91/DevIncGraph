using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIncGraph.Models.ViewModels
{
    public class IndexViewModel
    {
        public UserData UserData { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}
