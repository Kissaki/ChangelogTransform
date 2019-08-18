using KCode.ChangelogTransform.Models;
using KCode.ChangelogTransform.Transformers.Mappings;
using KCode.ChangelogTransform.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KCode.ChangelogTransform.Transformers
{
    public class ItemCategorizer
    {
        public Dictionary<Category, List<Commit>> Categories { get; } = new Dictionary<Category, List<Commit>>();

        public ItemCategorizer()
        {
            foreach (Category? cateory in Enum.GetValues(typeof(Category)))
            {
                if (cateory == null)
                {
                    throw new InvalidOperationException($"Unexpected: {nameof(Enum.GetValues)} returned a null value in the result");
                }

                Categories.Add(cateory.Value, new List<Commit>());
            }
        }

        public void Add(Commit item)
        {
            if (IgnoredCommits.Commits.Contains(item.Hash))
            {
                return;
            }

            var category = GetLineCategory(item);
            Categories[category].Add(item);
        }

        private Category GetLineCategory(Commit item)
        {
            var hash = item.Hash;
            var title = item.Title;

            if (CommitCategories.CommitMappingTransformed.TryGetValue(hash, out var mappedCategory))
            {
                return mappedCategory;
            }
            if (IsWordMatch(title, "translation", "Translation", "translations", ".ts", "MumbleTransifexBot"))
            {
                return Category.Translation;
            }
            if (title.StartsWith("Overlay") || title.StartsWith("overlay")
                || IsWordMatch(title, "overlay", "OverlayClient", "Overlay", "drawOverlay", "overlays", "OverlayPrivateWin", "overlay_exe", "overlay_gl", "OverlayConfig", "mumble_ol", "HardHook", "winhook", "Hooks")
                )
            {
                return Category.Overlay;
            }
            if (title.StartsWith("plugins/") || title.StartsWith("Plugins") || title.Contains("positional audio") || IsWordMatch(title, "PA", "Plugin", "Plugins", "plugins", "plugin"))
            {
                return Category.PositionalAudio;
            }
            if (IsWordMatch(title, "installer"))
            {
                return Category.Installer;
            }
            if (title.Contains("3rdparty"))
            {
                return Category.Thirdparty;
            }
            if (title.Contains("theme") || IsWordMatch(title, "icon", "icons", "ApplicationPalette"))
            {
                return Category.Theme;
            }
            if (title.StartsWith("Bump version") || title.Contains("QT_") || title.Contains("Q_")
                || IsWordMatch(title, "submodule", "build", "compiler.pri", "header guard", "refac", "Refac", "refacs", "Refactor", "Refactoring", "guard define", ".pri", "qmake", "LICENSE", "license", "CHANGES", @"C\+\+11")
                )
            {
                return Category.Code;
            }
            if (IsWordMatch(title, "grpc"))
            {
                return Category.Grpc;
            }
            if (IsWordMatch(title, "Ice", "ice"))
            {
                return Category.Ice;
            }
            if (IsWordMatch(title, "protocol documentation"))
            {
                return Category.ProtocolDocumentation;
            }
            if (IsWordMatch(title, "scripts", ".pro", "buildenv", "travis-ci", "appveyor"))
            {
                return Category.BuildInfrastructure;
            }
            if (title.StartsWith("src/tests") || title.StartsWith("tests/") || IsWordMatch(title, "OverlayTest", "tests"))
            {
                return Category.Tests;
            }
            if (IsWordMatch(title, "Opus"))
            {
                return Category.Opus;
            }
            if (IsWordMatch(title, "bonjour"))
            {
                return Category.Bonjour;
            }
            if (IsWordMatch(title, "Qt 5", "Qt5"))
            {
                return Category.Qt5;
            }
            if (IsWordMatch(title, "Qt 4", "Qt4"))
            {
                return Category.Qt4;
            }
            if (title.StartsWith("GlobalShortcut") || IsWordMatch(title, "GlobalShortcut", "Shortcut", "shortcut"))
            {
                return Category.GlobalShortcut;
            }
            if (IsWordMatch(title, "BanList", "Banlist"))
            {
                return Category.BanList;
            }
            if (title.StartsWith("OSInfo"))
            {
                return Category.OSInfo;
            }
            if (IsWordMatch(title, "Fix", "Fixes", "Fixed", "fix"))
            {
                return Category.Bugfixes;
            }
            if (IsWordMatch(title, "LCD", "G15", "g15helper"))
            {
                return Category.G15Lcd;
            }
            if (IsWordMatch(title, "filter", "filtering"))
            {
                return Category.Filter;
            }
            if (title.StartsWith("TextToSpeech"))
            {
                return Category.TextToSpeech;
            }
            if (title.Contains("OPENSSL") || IsWordMatch(title, "SSL", "ssl", "sslCiphers", "sslciphers", "SSLCipherInfo", "lssl", "OpenSSL", "QSslSocket", "QSslSocket", "SSLCipherInfoTable", "OPENSSL"))
            {
                return Category.SSL;
            }

            return Category.Misc;
        }

        private bool IsWordMatch(string text, params string[] words) => words.Any(word => Regex.IsMatch(text, $@"\b{word}\b"));
    }
}
