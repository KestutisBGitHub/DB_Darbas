using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Darbas
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [DefaultValue("user")]
        public string? Role { get; set; }
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
