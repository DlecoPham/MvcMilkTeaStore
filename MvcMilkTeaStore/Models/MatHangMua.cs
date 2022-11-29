using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMilkTeaStore.Models
{
    public class MatHangMua
    {
        QLBANTRASUAEntities db=new QLBANTRASUAEntities();
        public int MaTraSua { get; set; }
        public string TenTraSua { get; set; }
        public  string AnhBia { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
        public MatHangMua(int MaTraSua)
        {
            this.MaTraSua = MaTraSua;

            //Tìm trà sữa trong CSDL có mã id cần và gán cho mặt hàng được mua
            var trasua = db.TRASUAs.Single(s => s.Matrasua == this.MaTraSua);
            this.TenTraSua = trasua.Tentrasua;
            this.AnhBia = trasua.Hinhminhhoa;
            this.DonGia = double.Parse(trasua.Dongia.ToString());
            this.SoLuong = 1; //Số lượng mua ban đầu của một mặt hàng là 1 (cho lần click đầu)
        }
    }
}