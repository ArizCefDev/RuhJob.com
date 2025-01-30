namespace RuhJob.com.DataAccess.Entity
{
    public class Category
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }

    }
}
