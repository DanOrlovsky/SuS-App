using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.Models
{
    public partial class Home : BaseEntity
    {
        public string BuyerNames { get; set; }

        public string Address { get; set; }

        public int LotNumber { get; set; }

        public string Notes { get; set; }

        public double PurchasePrice { get; set; }

        public double UpgradePrice { get; set; }

        public bool HasApproved { get; set; }

        public virtual List<SelectionCategory> SelectionCategories { get; set; }
    }
}
