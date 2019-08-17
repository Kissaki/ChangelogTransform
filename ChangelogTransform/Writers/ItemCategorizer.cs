using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace changelog_transform.Writers
{
    class ItemCategorizer
    {
        private static List<string> IgnoreHash = new List<string>
        {
        };

        private static Dictionary<Category, string[]> CommitMapping = new Dictionary<Category, string[]>
        {
            { Category.Features, new string[] {
                "c40b0b00",
                "304bf438",
                "7c2d1a3f",
                "405d6e43",
                "52d19ac3",
                "fd5a9b12",
                "6a345f54",
                "29a65c66",
                "02ddd914",
                // syslog
                "30023c5b",
                // syslog
                "322ed8a1",
                // syslog
                "08d7cb3a",
                // syslog
                "094ab1e1",
                // disable su
                "f990b90d",
                // disable su
                "aaf36667",
                // disable su
                "708ace45",
                "f0fc66b6",
                "88cf21d6",
                "a5651973",
                "44dc94e9",
                "bc5852d3",
                "80f1623b",
                "dede3178",
                "57396fac",
                "5b104e09",
                "de27cd7b",
            } },
            { Category.Improvements, new string[] {
                "679eacd7",
                "b422e0a9",
                "f07f0c86",
                "cde56107",
                "d9d81a99",
                "3e0112da",
                "d3e00dee",
                "1eefaab0",
                "b2d938ba",
                "b7d9387b",
                "97cf80de",
                "d299360f",
                "1375022b",
                "dd7cc7ca",
                "3c280a66",
                "76475381",
                "71ff77b2",
                "d9785f9f",
                "44a08461",
                "9cc1c0a7",
                "ad19d157",
                "5a033b8b",
                "525995d1",
                "9ba92b58",
                "f5affcd4",
                "67ed33f3",
                "445cdf0e",
                "2c0d37f9",
                "b2282e74",
                "4e459a9b",
                "ab78e6c9",
            } },
            { Category.Bugfixes, new string[] {
                "77233edf",
                "ed424afa",
                "ea165cde",
                "abad339f",
                "63f35d6a",
                // VoiceRecorder
                "1c00533b",
                "78604d85",
            } },
            { Category.Hardening, new string[] {
                "b6e17cac",
                "9837c4dc",
                "17fa695b",
                "d9ff1e94",
                "527d24ed",
                "e438a05f",
                "e740ea5e",
                "996a3df4",
            } },
            { Category.BuildInfrastructure, new string[] {
                "7d649aa5",
                "d74b5b04",
                "82fa0e60",
                "c03d8fcc",
                "b2529590",
                "53daac83",
                "9946dc75",
                "e562e92e",
                "a429c763",
                "630a17ba",
                "0fdb7c17",
            } },
            { Category.Code, new string[] {
                #region collapse
                "8b044264",
                "14597920",
                "708212ab",
                "f09e943b",
                "487ed147",
                "bb47083b",
                "b0707fd1",
                "9450d669",
                "f4c54b24",
                "b004a4ce",
                "676bb0e3",
                "33069f82",
                "46fc3ccf",
                "84bc19c8",
                "7b68d0ce",
                "2c07833d",
                "84be1eb1",
                "36217acc",
                "2cec7bae",
                "1011d530",
                "5f98a656",
                "229f0419",
                "39697c79",
                "192135db",
                "f5141076",
                "67914c3c",
                "b5ee1f4c",
                "2ac3b67b",
                "da6c2444",
                "34943628",
                "1caaec76",
                "a0ebded7",
                "c52dedce",
                "1f6ddaf3",
                "22d87409",
                "abdb5ac1",
                "4f7ede51",
                "cdcf77c0",
                "769855b4",
                "8540e08a",
                "d1a19d46",
                "9d668ebc",
                "34daf712",
                "12eb2643",
                "fc5fd45f",
                "83218f11",
                "e9e2680f",
                "4a149f8f",
                "b4f0c66c",
                "236e9874",
                "1bd6c883",
                "b78f34d0",
                "124b1ceb",
                "6a07cbd1",
                "2418b806",
                #endregion
                "a7dd1b77",
                "21a15190",
                "e24cfe6c",
                "0f072ef0",
                "c005fe34",
                "15fbe1d7",
                "d9e0d08f",
                "9ee9e8ad",
            } },
            { Category.Translation, new string[] {
                "52272e28",
                "8632246f",
                "de2e0868",
                "f1eb6425",
            } },
            { Category.PositionalAudio, new string[] {
                "398b7733",
                "61ad05c9",
                "9f6c08b2",
                "9f327bee",
                "19efac30",
            } },
            { Category.Thirdparty, new string[] {
                "3aa91793",
            } },
            { Category.Installer, new string[] {
                "fcc2a390",
                "e7282052",
            } },
            { Category.Theme, new string[] {
                "7fbd9d43",
            } },
            { Category.Overlay, new string[] {
                "0e358bff",
            } },
            { Category.ProtocolDocumentation, new string[] {
                "6eecd624",
                "eda74f21",
            } },
        };
        private static Dictionary<string, Category> CommitMappingTransformed = CommitMapping.SelectMany(x => x.Value, (x, y) => new KeyValuePair<string, Category>(y, x.Key)).ToDictionary(x => x.Key, x => x.Value);

        public Dictionary<Category, List<HistoryItem>> Categories { get; } = new Dictionary<Category, List<HistoryItem>>();

        public ItemCategorizer()
        {
            foreach (Category cateory in Enum.GetValues(typeof(Category)))
            {
                Categories.Add(cateory, new List<HistoryItem>());
            }
        }

        public void Add(HistoryItem item)
        {
            if (IgnoreHash.Contains(item.Hash))
            {
                return;
            }

            var category = GetLineCategory(item);
            Categories[category].Add(item);
        }

        private Category GetLineCategory(HistoryItem item)
        {
            var hash = item.Hash;
            var title = item.Title;

            if (CommitMappingTransformed.TryGetValue(hash, out var mappedCategory))
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
