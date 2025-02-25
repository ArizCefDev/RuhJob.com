namespace RuhJob.com.DataAccess.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Roleid { get; set; }
        public Role Role { get; set; }
    }
}
