//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRental.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarModels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarModels()
        {
            this.Cars = new HashSet<Cars>();
        }
    
        public int IdCarModels { get; set; }
        public int IdBrand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public double Deposit { get; set; }
        public double Acceleration { get; set; }
        public int MaxSpeed { get; set; }
        public int YearOfIssue { get; set; }
        public string Image { get; set; }
        public string ImageAbove { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars> Cars { get; set; }
    }
}
