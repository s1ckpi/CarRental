using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public partial class CarModels
    {
        public string ImageCarPath
        {
            get
            {
                string productImage;
                productImage = "..\\..\\Resources\\Images\\" + Image.Trim();
                return productImage;
            }
        }
    }
}
