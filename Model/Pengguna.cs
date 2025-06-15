using System;

namespace Kinar_Bakery.Model
{
    public class Pengguna : UserBase
    {
        private int _id_user;
        private string? _nama;
        private string? _username;
        private string? _password;
        private string? _nomor_telepon;
        private string? _alamat;
        private string? _role;
        private DateTime? _tanggal_lahir;

        public new int Id_user { get => _id_user; set => _id_user = value; }
        public new string? Nama { get => _nama; set => _nama = value; }
        public new string? Username { get => _username; set => _username = value; }
        public new string? Password { get => _password; set => _password = value; }
        public new string? Nomor_telepon { get => _nomor_telepon; set => _nomor_telepon = value; }
        public new string? Alamat { get => _alamat; set => _alamat = value; }
        public new string? Role { get => _role; set => _role = value; }
        public new DateTime? Tanggal_lahir { get => _tanggal_lahir; set => _tanggal_lahir = value; }

        public override string GetRoleDetails()
        {
            return $"{base.GetRoleDetails()} Pelanggan";
        }
    }
}