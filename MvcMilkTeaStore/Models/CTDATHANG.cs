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
    
    public partial class CTDATHANG
    {
        public int SoDH { get; set; }
        public int Matrasua { get; set; }
        public Nullable<int> Soluong { get; set; }
        public Nullable<decimal> Dongia { get; set; }
        public Nullable<decimal> Thanhtien { get; set; }
    
        public virtual DONDATHANG DONDATHANG { get; set; }
        public virtual TRASUA TRASUA { get; set; }
    }
}
