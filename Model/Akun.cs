using System;

namespace Kinar_Bakery.Model
{
    public class Akun : UserBase
    {
        public override string GetRoleDetails()
        {
            return $"Akun - {base.GetRoleDetails()} (Registrasi: {Tanggal_lahir?.ToString("dd/MM/yyyy") ?? "Tidak ada"})";
        }
    }
}