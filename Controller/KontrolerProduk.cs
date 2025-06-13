using Kinar_Bakery.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinar_Bakery.Controller
{
    public class KontrolerProduk
    {
        private readonly KonteksProduk _konteks = new KonteksProduk();
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

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

        //public class KontrolerProduk
        //{
        //    private readonly DatabaseConnection _dbConnection;

        //    public KontrolerProduk()
        //    {
        //        _dbConnection = new DatabaseConnection();
        //    }

        //    public List<Produk> CariProduk(string keyword)
        //    {
        //        var daftarProduk = new List<Produk>();

        //        string query = @"
        //        SELECT id_produk, nama, jenis, harga
        //        FROM public.produk
        //        WHERE LOWER(nama) LIKE LOWER(@keyword) OR LOWER(jenis) LIKE LOWER(@keyword)
        //        ORDER BY nama";

        //        var parameter = new[] {
        //        new NpgsqlParameter("@keyword", $"%{keyword}%")
        //    };

        //        DataTable hasil = _dbConnection.ExecuteQuery(query, parameter);

        //        foreach (DataRow row in hasil.Rows)
        //        {
        //            daftarProduk.Add(new Produk
        //            {
        //                Id_produk = Convert.ToInt32(row["id_produk"]),
        //                Nama = row["nama"].ToString(),
        //                Jenis = row["jenis"].ToString(),
        //                Harga = Convert.ToDecimal(row["harga"])
        //            });
        //        }

        //        return daftarProduk;
        //    }
        public List<Produk> CariProduk(string keyword)
        {
            string query = @"
        SELECT p.id_produk, p.nama, p.jenis, kp.harga
        FROM public.produk p
        JOIN public.katalog_produk kp ON p.id_produk = kp.id_produk
        WHERE LOWER(p.nama) LIKE LOWER(@keyword) OR LOWER(p.jenis) LIKE LOWER(@keyword)";

            var parameters = new[]
            {
        new NpgsqlParameter("@keyword", "%" + keyword + "%")
    };

            var result = new DatabaseConnection().ExecuteQuery(query, parameters);
            var daftarProduk = new List<Produk>();

            foreach (DataRow row in result.Rows)
            {
                daftarProduk.Add(new Produk
                {
                    Id_produk = Convert.ToInt32(row["id_produk"]),
                    Nama = row["nama"].ToString(),
                    Jenis = row["jenis"].ToString(),
                    Harga = Convert.ToDecimal(row["harga"])
                });
            }

            return daftarProduk;
        }
    }
}