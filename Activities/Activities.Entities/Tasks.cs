namespace Activities.Entities
{
    public class Tasks
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool bit { get; set; }
        public string priority { get; set; }
        public DateTime due_date { get; set; }
        public DateTime created_at { get; set; }

    }
}
