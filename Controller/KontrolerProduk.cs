using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinar_Bakery.Controller
{
    public class KontrolerProduk
    {
        private readonly KonteksProduk _konteks = new KonteksProduk();

        public List<Produk> AmbilSemuaProduk(string opsiUrut = null)
        {
            return _konteks.AmbilSemua(opsiUrut);
        }

        public List<Produk> AmbilBestSeller()
        {
            return _konteks.AmbilBestSeller();
        }

        public void TambahKeKeranjang(int id_produk, int jumlah, int id_user)
        {
            var produk = _konteks.AmbilBerdasarkanId(id_produk.ToString());
            if (produk != null && produk.Stok >= jumlah)
            {
                var konteksTransaksi = new KonteksTransaksi();
                konteksTransaksi.TambahPesananSementara(id_produk, jumlah, id_user);
            }
            else
            {
                throw new Exception("Stok tidak cukup atau produk tidak ditemukan!");
            }
        }

        public Produk AmbilBerdasarkanId(string id_produk)
        {
            return _konteks.AmbilBerdasarkanId(id_produk);
        }

        private decimal AmbilHargaProduk(int id_produk)
        {
            string query = "SELECT harga FROM public.katalog_produk WHERE id_produk = @id";
            var parameters = new[] { new NpgsqlParameter("@id", id_produk) };
            var result = new DatabaseConnection().ExecuteQuery(query, parameters);
            return result.Rows.Count > 0 ? Convert.ToDecimal(result.Rows[0]["harga"]) : 0;
        }
    }
}