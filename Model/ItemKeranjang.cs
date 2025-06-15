using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinar_Bakery.Model
{
    public class ItemKeranjang
    {
        public int Id_produk { get; set; }
        public string? Nama_produk { get; set; }
        public int Jumlah { get; set; }
        public decimal? Total_harga { get; set; }
        public string? Status { get; set; }
    }
}


