using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public partial class Clients
    {
        public string ClientsImage
        {
            get
            {
                string ClientImage;
                ClientImage = "..\\..\\Assets\\Images\\" + ImageClient.Trim();
                return ClientImage;
            }
        }
    }
}
