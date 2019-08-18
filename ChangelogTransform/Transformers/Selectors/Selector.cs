using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Types;
using System;
using System.Text.RegularExpressions;

namespace KCode.ChangelogTransform.Transformers.Selectors
{
    public class Selector : ISelector
    {
        public SelectorType Type { get; }
        public string Text { get; }

        public Selector(SelectorType type, string text)
        {
            Type = type;
            Text = text;
        }

        public bool IsMatch(Commit commit)
        {
            switch (Type)
            {
                case SelectorType.CommitHash:
                    return commit.Hash == Text;
                case SelectorType.StartsWith:
                    return commit.Title.StartsWith(Text);
                case SelectorType.Contains:
                    return commit.Title.Contains(Text);
                case SelectorType.ContainsWord:
                    var regex = new Regex(@$"\b{Text}\b");
                    return regex.IsMatch(commit.Title);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
