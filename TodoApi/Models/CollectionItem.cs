using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class CollectionItem
    {
        public string Name { get; set; }
        public string[] Type { get; set; }
        public int Size { get; set; }
    }
}
