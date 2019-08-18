using KCode.ChangelogTransform.Types;
using System.Collections.Generic;

namespace KCode.ChangelogTransform.Models
{
    public class HistoryItem
    {
        public string Title { get; }
        public Category Category { get; }
        public List<Commit> Commits { get; } = new List<Commit>();

        public HistoryItem(string title, Category category, params Commit[] commits)
        {
            Title = title;
            Category = category;

            foreach (var commit in commits)
            {
                AddCommit(commit);
            }
        }

        private void AddCommit(Commit commit) => Commits.Add(commit);
    }
}
