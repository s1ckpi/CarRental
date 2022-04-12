using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{

    public partial class Cars
    {
        public string BackColor
        {
            get
            {
                if (Availability == 1 || Availability == null)
                    return "#ff9e9e";
                else
                    return "#d1ffd1";
            }
        }
    }
}
