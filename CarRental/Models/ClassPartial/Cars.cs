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
                if (Availability == 2)
                {
                    return "#fffead";
                }
                else 
                {
                    if (Availability == 1 || Availability == null)
                        return "#ffadad";
                    else
                        return "#aeffad";
                }
                
            }
        }

        public string TextColor
        {
            get
            {
                if (Availability == 2)
                {
                    return "#ffd600";
                }
                else 
                {
                    if (Availability == 1 || Availability == null)
                        return "#990000";
                    else
                        return "#0fff00";
                }
                
            }
        }

        public string TextAvailability
        {
            get
            {
                if (Availability == 2)
                {
                    return "На ремонте";
                }
                else
                {
                    if (Availability == 1 || Availability == null)
                        return "Занят";
                    else
                        return "Свободен";
                }

            }
        }
    }
}
