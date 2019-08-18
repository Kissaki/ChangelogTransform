using KCode.ChangelogTransform.Types;
using System.Collections.Generic;

namespace KCode.ChangelogTransform.Models
{
    public class HistoryItem
    {
        public string Title { get; }
        public Category Category { get; }
        public Commit[] Commits { get; }

        public HistoryItem(string title, Category category, params Commit[] commits)
        {
            Title = title;
            Category = category;

            Commits = commits;
        }
    }
}
