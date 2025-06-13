using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinar_Bakery.Model
{
    public interface ILaporan
    {
        DataTable AmbilData(DateTime tanggalAwal, DateTime tanggalAkhir);
    }
}