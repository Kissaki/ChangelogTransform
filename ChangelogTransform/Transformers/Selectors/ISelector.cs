using KCode.ChangelogTransform.Models;

namespace KCode.ChangelogTransform.Transformers.Selectors
{
    public interface ISelector
    {
        bool IsMatch(Commit commit);
    }
}
