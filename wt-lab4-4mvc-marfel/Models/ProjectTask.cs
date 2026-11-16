namespace wt_lab4_4mvc_marfel.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Assignee { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}