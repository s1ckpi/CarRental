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
                string AutomobileImage;
                AutomobileImage = "..\\..\\Assets\\Images\\" + Image.Trim();
                return AutomobileImage;
            }
        }

        public string ImageCarAbovePath
        {
            get
            {
                string AutomobileAboveImage;
                AutomobileAboveImage = "..\\..\\Assets\\Images\\" + ImageAbove.Trim();
                return AutomobileAboveImage;
            }
        }
    }
}
