using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameManager.Models
{
    public class GameModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Developer { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public string Path { get; set; }
        public string Arguments { get; set; }
    }
}
