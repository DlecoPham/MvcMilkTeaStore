//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcMilkTeaStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRASUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRASUA()
        {
            this.CTDATHANGs = new HashSet<CTDATHANG>();
        }
    
        public int Matrasua { get; set; }
        public string Tentrasua { get; set; }
        public string Donvitinh { get; set; }
        public Nullable<decimal> Dongia { get; set; }
        public string Mota { get; set; }
        public string Hinhminhhoa { get; set; }
        public Nullable<int> MaCD { get; set; }
        public Nullable<System.DateTime> Ngaycapnhat { get; set; }
        public Nullable<int> Soluongban { get; set; }
        public Nullable<int> solanxem { get; set; }
    
        public virtual CHUDE CHUDE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }
    }
}
