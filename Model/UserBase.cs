namespace Kinar_Bakery.Model
{
    public abstract class UserBase
    {
        public int Id_user { get; set; }
        public string? Nama { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nomor_telepon { get; set; }
        public string? Alamat { get; set; }
        public string? Role { get; set; }
        public DateTime? Tanggal_lahir { get; set; }

        public virtual string GetRoleDetails()
        {
            return $"Role: {Role}";
        }
    }
}