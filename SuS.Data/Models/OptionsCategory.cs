using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Models
{
    public partial class OptionsCategory : BaseEntity
    {
        public int SelectionCategoryId { get; set; }

        public string Name { get; set; }

        public virtual SelectionCategory SelectionCategory { get; set; }

        public virtual List<Option> Options { get; set; }
    }
}
