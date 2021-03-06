//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFirst.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Computer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Computer()
        {
            this.Gpus = new HashSet<Gpu>();
            this.StorageDevices = new HashSet<StorageDevice>();
        }
    
        public int Id { get; set; }
        public int Type { get; set; }
        public int VendorId { get; set; }
        public string Model { get; set; }
        public int CpuId { get; set; }
        public string Memory { get; set; }
    
        public virtual Cpu Cpu { get; set; }
        public virtual Vendor Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gpu> Gpus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StorageDevice> StorageDevices { get; set; }
    }
}
