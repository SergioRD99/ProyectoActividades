namespace Activities.Entities
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public string password_hash { get; set; }

        public DateTime created_at { get; set; }
    }
}
