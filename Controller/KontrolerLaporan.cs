using Kinar_Bakery.Model;
using System;
using System.Data;

namespace Kinar_Bakery.Controller
{
    public class KontrolerLaporan
    {
        private readonly ILaporan _laporanPembelian;
        private readonly ILaporan _laporanPenjualan;

        public KontrolerLaporan()
        {
            _laporanPembelian = new LaporanPembelian();
            _laporanPenjualan = new LaporanPenjualan();
        }

        public DataTable AmbilLaporan(string jenisLaporan, DateTime tanggalAwal, DateTime tanggalAkhir)
        {
            if (jenisLaporan == "Pembelian")
                return _laporanPembelian.AmbilData(tanggalAwal, tanggalAkhir);
            else if (jenisLaporan == "Penjualan")
                return _laporanPenjualan.AmbilData(tanggalAwal, tanggalAkhir);
            else
                return new DataTable();
        }
    }
}