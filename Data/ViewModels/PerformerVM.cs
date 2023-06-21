using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class PerformerVM
    {
        public int PerformerId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? CareerBeginYear { get; set; }

        public string? Img { get; set; }

        public virtual string? Country { get; set; }
        public virtual List<string> PerformerGenres { get; set; } = new List<string>();

        public virtual string? PerformerType { get; set; }
    }
}
