using SuS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuS.Web.ViewModels
{
    public class AddNewHomeViewModel
    {

        [Display(Name ="Buyer Name(s)")]
        [Required(ErrorMessage = "You must enter a buyers' name.")]
        public string BuyerNames { get; set; }

        [Display(Name ="Property Addresss")]
        public string Address { get; set; }

        [Display(Name ="Lot Number")]
        public int LotNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        public double PurchasePrice { get; set; }

        public string PurchasePriceDisplay
        {
            get
            {
                string temp = "";
                int ctr = (PurchasePrice.ToString().Length % 3);
                for (int i = 0; i < PurchasePrice.ToString().Length; i++)
                {
                    
                    temp += PurchasePrice.ToString()[i];
                    if(ctr % 3 == 0)
                    {
                        temp += ",";
                    }
                    ctr++;
                }

                return temp;
            }
        }

        public static Home ConvertToHomeModel(string buyerNames, string address, int lotNumber, string notes, double purchasePrice)
        {
            return new Home {
                BuyerNames = buyerNames,
                Address = address,
                LotNumber = lotNumber,
                Notes = notes,
                PurchasePrice = purchasePrice
            };
        }
    }
}