using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Types;
using System;
using System.IO;
using System.Linq;

namespace KCode.ChangelogTransform.Writers
{
    public abstract class HistoryWriter
    {
        protected static Category[] CategoryValues = Enum.GetValues(typeof(Category)).Cast<Category>().ToArray();
        protected static string CategoryName(Category category) => Enum.GetName(typeof(Category), category) ?? throw new InvalidOperationException();

        protected FileInfo TargetFile { get; }

        protected HistoryWriter(string filename)
        {
            TargetFile = new FileInfo(filename);
        }

        protected string CreateCommitPrLink(int id)
        {
            return @$"<a class=""pr-link"" href=""https://github.com/mumble-voip/mumble/pull/{id}"">#{id}</a>";
        }

        protected string CreateCommitHashLink(Commit commit)
        {
            var commitUrl = $"https://github.com/mumble-voip/mumble/commit/{commit.Hash}";
            return @$"<a class=""commit-hashlink"" href=""{commitUrl}"" title=""{commit.Title}"">{commit.Hash}</a>";
        }
    }
}
