using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPGProject.Models
{
    public class Item
    {
        public string Name { get; set; } = "";
        public float Price { get; set; } = 0;

        public List<string> Colours { get; set; } = new List<string>();
        public List<int> Quantity { get; set; } = new List<int>(); 

    }
}
