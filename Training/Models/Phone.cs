using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Maker { get; set; }
        public int Price { get; set; }
    }
}
