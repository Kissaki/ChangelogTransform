using KCode.ChangelogTransform.Models;
using System.Linq;

namespace KCode.ChangelogTransform.Transformers.Selectors
{
    class CommitSelector : ISelector
    {
        private string[] Hashes { get; }

        public CommitSelector(params string[] hashes)
        {
            Hashes = hashes;
        }

        public bool IsMatch(Commit commit) => Hashes.Any(x => x == commit.Hash);
    }
}
