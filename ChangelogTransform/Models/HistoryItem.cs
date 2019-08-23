using KCode.ChangelogTransform.Types;

namespace KCode.ChangelogTransform.Models
{
    public class HistoryItem
    {
        public string Title { get; }
        public Category Category { get; }
        public Commit[] Commits { get; }
        public string? Description { get; set; }

        public HistoryItem(string title, Category category, params Commit[] commits)
        {
            Title = title;
            Category = category;

            Commits = commits;
        }
    }
}
