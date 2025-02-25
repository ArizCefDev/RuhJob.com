namespace RuhJob.com.DataAccess.Entity
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
