namespace Activities.Entities
{
    public class TaskHistory
    {
        public int id { get; set; }
        public int task_id { get; set; }
        public int changed_by { get; set; }

        public DateTime change_date { get; set; }

        public string change_description { get; set; }
    }
}
