using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Models
{
    public partial class Option : BaseEntity
    {
        public int OptionsCategoryId { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public string ModelNumber { get; set; }

        public double Price { get; set; }

        public double ActualCost { get; set; }

        public bool Selected { get; set; }
    }
}
