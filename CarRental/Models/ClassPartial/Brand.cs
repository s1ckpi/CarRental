using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public partial class Brand
    {
        public string ImageBrandLogoPath
        {
            get
            {
                string BrandLogoImagePath;
                BrandLogoImagePath = "..\\..\\Assets\\Images\\" + BrandLogo.Trim();
                Console.WriteLine(BrandLogoImagePath);
                return BrandLogoImagePath;
            }
        }
    }
}
