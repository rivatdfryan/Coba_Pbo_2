using System;
using System.Data;

namespace Kinar_Bakery.Model
{
    public interface ILaporan
    {
        DataTable AmbilData(DateTime tanggalAwal, DateTime tanggalAkhir);
    }
}