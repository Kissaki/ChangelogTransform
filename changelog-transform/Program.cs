using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace changelog_transform
{
    class Program
    {
        private static readonly string Source = "1.2.19";
        private static readonly string Target = "1.3.0-rc2";
        private static readonly string RepoPath = @"C:\dev\mumble\mumble\mumble\";
        private static readonly DirectoryInfo Repo = new DirectoryInfo(RepoPath);

        private static readonly string GitLogParameters = $"log {Source}..{Target} --first-parent --reverse --oneline";
        private static readonly int HashLength = 8;

        private static readonly string HistoryStore = "Store_History";
        private static Group[] GroupValues = Enum.GetValues(typeof(Group)).Cast<Group>().ToArray();
        private static string GroupName(Group group) => Enum.GetName(typeof(Group), group);

        private enum Group
        {
            // Everything uncategorized
            Misc,

            // New features
            Features,
            // Improvements - could be split into GUI, admin, user, hidden/expert, etc
            Improvements,
            // Fixed bugs
            Bugfixes,
            // Fixed issues or potential/theoretical issues
            Hardening,

            // Everything build scripts, build configuration, build job configuration
            BuildInfrastructure,
            // Code formatting, being able to compile on different platforms, code improvements - could be split up further
            Code,
            // Related to translation of Mumble and installer
            Translation,
            // Tests, test programs, src/tests
            Tests,
            ProtocolDocumentation,

            Overlay,
            PositionalAudio,
            Installer,
            Thirdparty,
            Theme,
            Grpc,
            Ice,
            Opus,
            Bonjour,
            Qt5,
            GlobalShortcut,
            BanList,
            OSInfo,
            G15Lcd,
            Filter,
            TextToSpeech,
            Qt4,
            SSL,
        };
        private static Dictionary<Group, List<string>> Groups = new Dictionary<Group, List<string>>();
        private static Dictionary<Group, string[]> CommitMapping = new Dictionary<Group, string[]>
        {
            { Group.Features, new string[] {
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
            { Group.Improvements, new string[] {
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
            { Group.Bugfixes, new string[] {
                "77233edf",
                "ed424afa",
                "ea165cde",
                "abad339f",
                "63f35d6a",
                // VoiceRecorder
                "1c00533b",
                "78604d85",
            } },
            { Group.Hardening, new string[] {
                "b6e17cac",
                "9837c4dc",
                "17fa695b",
                "d9ff1e94",
                "527d24ed",
                "e438a05f",
                "e740ea5e",
                "996a3df4",
            } },
            { Group.BuildInfrastructure, new string[] {
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
            { Group.Code, new string[] {
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
            { Group.Translation, new string[] {
                "52272e28",
                "8632246f",
                "de2e0868",
                "f1eb6425",
            } },
            { Group.PositionalAudio, new string[] {
                "398b7733",
                "61ad05c9",
                "9f6c08b2",
                "9f327bee",
                "19efac30",
            } },
            { Group.Thirdparty, new string[] {
                "3aa91793",
            } },
            { Group.Installer, new string[] {
                "fcc2a390",
                "e7282052",
            } },
            { Group.Theme, new string[] {
                "7fbd9d43",
            } },
            { Group.Overlay, new string[] {
                "0e358bff",
            } },
            { Group.ProtocolDocumentation, new string[] {
                "6eecd624",
                "eda74f21",
            } },
        };
        private static Dictionary<string, Group> CommitMappingTransformed = CommitMapping.SelectMany(x => x.Value, (x, y) => new KeyValuePair<string, Group>(y, x.Key)).ToDictionary(x => x.Key, x => x.Value);

        static void Main(string[] args)
        {
            Console.Title = "Changelog Transform";

            var history = GetGitHistory();
            if (history == null)
            {
                WriteError("Failed to get git history");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine($"Identified {history.Count} history items");
            }

            WriteLinearHistory("history-linear.html", history);

            CategorizeCommitsIntoGroups(history);
            WriteGroupedHistory("history-grouped.html");

            Console.WriteLine("ENTER to exit");
            //Console.ReadLine();
        }

        private static void WriteGroupedHistory(string filename)
        {
            var fi = new FileInfo(filename);

            using var fs = fi.CreateText();
            fs.WriteLine("<h1>Grouped Changes</h1>");

            var isFirst = true;
            foreach (Group group in GroupValues)
            {
                fs.Write(CreateGroup(group, isOpen: isFirst));
                isFirst = false;
            }
        }

        private static string CreateGroup(Group group, bool isOpen)
        {
            var sb = new StringBuilder();

            var lines = Groups[group];
            var openAttribute = isOpen ? "open" : "";
            sb.AppendLine(@$"<details {openAttribute}><summary><h2 style=""display:inline"">{GroupName(group)}</h2> ({lines.Count})</summary>");

            sb.AppendLine("<table>");
            foreach (var line in lines)
            {
                var (hash, title) = ParseLine(line);
                sb.AppendLine(CreateLinearHistoryLine(line));
            }
            sb.AppendLine("</table></details>");

            return sb.ToString();
        }

        private static void CategorizeCommitsIntoGroups(List<string> history)
        {
            foreach (Group group in GroupValues)
            {
                Groups.Add(group, new List<string>());
            }

            foreach (var line in history)
            {
                GroupLine(line);
            }

            Console.WriteLine("Grouped:");
            foreach (Group group in GroupValues)
            {
                Console.WriteLine($"* {Enum.GetName(typeof(Group), group)} {Groups[group].Count}");
            }
        }

        private static (string hash, string title) ParseLine(string line)
        {
            var hash = line.Substring(0, HashLength);
            var title = line.Substring(HashLength + 1);
            return (hash, title);
        }

        private static void GroupLine(string line)
        {
            if (line == null)
            {
                Console.WriteLine("WARN: line is null");
                return;
            }

            var group = GetLineGroup(line);
            Groups[group].Add(line);
        }

        private static Group GetLineGroup(string line)
        {
            var (hash, title) = ParseLine(line);

            if (CommitMappingTransformed.TryGetValue(hash, out var mappedGroup))
            {
                return mappedGroup;
            }
            else if (IsWordMatch(title, "translation", "Translation", "translations", ".ts", "MumbleTransifexBot"))
            {
                return Group.Translation;
            }
            else if (title.StartsWith("Overlay") || title.StartsWith("overlay")
                || IsWordMatch(title, "overlay", "OverlayClient", "Overlay", "drawOverlay", "overlays", "OverlayPrivateWin", "overlay_exe", "overlay_gl", "OverlayConfig", "mumble_ol", "HardHook", "winhook", "Hooks")
                )
            {
                return Group.Overlay;
            }
            else if (title.StartsWith("plugins/") || title.StartsWith("Plugins") || title.Contains("positional audio") || IsWordMatch(title, "PA", "Plugin", "Plugins", "plugins", "plugin"))
            {
                return Group.PositionalAudio;
            }
            else if (IsWordMatch(title, "installer"))
            {
                return Group.Installer;
            }
            else if (title.Contains("3rdparty"))
            {
                return Group.Thirdparty;
            }
            else if (title.Contains("theme") || IsWordMatch(title, "icon", "icons", "ApplicationPalette"))
            {
                return Group.Theme;
            }
            else if (title.StartsWith("Bump version") || title.Contains("QT_") || title.Contains("Q_")
                || IsWordMatch(title, "submodule", "build", "compiler.pri", "header guard", "refac", "Refac", "refacs", "Refactor", "Refactoring", "guard define", ".pri", "qmake", "LICENSE", "license", "CHANGES", @"C\+\+11")
                )
            {
                return Group.Code;
            }
            else if (IsWordMatch(title, "grpc"))
            {
                return Group.Grpc;
            }
            else if (IsWordMatch(title, "Ice", "ice"))
            {
                return Group.Ice;
            }
            else if (IsWordMatch(title, "protocol documentation"))
            {
                return Group.ProtocolDocumentation;
            }
            else if (IsWordMatch(title, "scripts", ".pro", "buildenv", "travis-ci", "appveyor"))
            {
                return Group.BuildInfrastructure;
            }
            else if (title.StartsWith("src/tests") || title.StartsWith("tests/") || IsWordMatch(title, "OverlayTest", "tests"))
            {
                return Group.Tests;
            }
            else if (IsWordMatch(title, "Opus"))
            {
                return Group.Opus;
            }
            else if (IsWordMatch(title, "bonjour"))
            {
                return Group.Bonjour;
            }
            else if (IsWordMatch(title, "Qt 5", "Qt5"))
            {
                return Group.Qt5;
            }
            else if (IsWordMatch(title, "Qt 4", "Qt4"))
            {
                return Group.Qt4;
            }
            else if (title.StartsWith("GlobalShortcut") || IsWordMatch(title, "GlobalShortcut", "Shortcut", "shortcut"))
            {
                return Group.GlobalShortcut;
            }
            else if (IsWordMatch(title, "BanList", "Banlist"))
            {
                return Group.BanList;
            }
            else if (title.StartsWith("OSInfo"))
            {
                return Group.OSInfo;
            }
            else if (IsWordMatch(title, "Fix", "Fixes", "Fixed", "fix"))
            {
                return Group.Bugfixes;
            }
            else if (IsWordMatch(title, "LCD", "G15", "g15helper"))
            {
                return Group.G15Lcd;
            }
            else if (IsWordMatch(title, "filter", "filtering"))
            {
                return Group.Filter;
            }
            else if (title.StartsWith("TextToSpeech"))
            {
                return Group.TextToSpeech;
            }
            else if (title.Contains("OPENSSL") || IsWordMatch(title, "SSL", "ssl", "sslCiphers", "sslciphers", "SSLCipherInfo", "lssl", "OpenSSL", "QSslSocket", "QSslSocket", "SSLCipherInfoTable", "OPENSSL"))
            {
                return Group.SSL;
            }

            return Group.Misc;
        }

        private static bool IsWordMatch(string text, params string[] words) => words.Any(word => Regex.IsMatch(text, $@"\b{word}\b"));

        private static void WriteLinearHistory(string filename, List<string> history)
        {
            var fi = new FileInfo(filename);
            if (fi.Exists)
            {
                Console.WriteLine("Linear history already exists; skipping");
                return;
            }

            using var fs = fi.CreateText();
            fs.WriteLine("<table>");
            fs.WriteLine("<th><td>Commit</td><td>PR</td><td>Title</td></th>");

            foreach (var line in history)
            {
                var link = CreateLinearHistoryLine(line);
                if (link == null)
                {
                    continue;
                }
                fs.WriteLine(link);
            }
            fs.WriteLine("</ul>");
        }

        private static string CreateLinearHistoryLine(string gitLine)
        {
            if (gitLine == null)
            {
                Console.WriteLine("WARN: line is null");
                return null;
            }
            var (hash, title) = ParseLine(gitLine);

            var commitUrl = $"https://github.com/mumble-voip/mumble/commit/{hash}";
            var commit = @$"<a href=""{commitUrl}"">{hash}</a>";

            var regPr = new Regex("((PR)|(pull request)) #(?<pr>[0-9]+)");
            var prMatch = regPr.Match(title);
            var pr = "";
            if (prMatch.Success)
            {
                var prId = int.Parse(prMatch.Groups["pr"].Value);
                pr = @$"<a href=""https://github.com/mumble-voip/mumble/pull/{prId}"">#{prId}</a>";
            }

            return $"<tr><td>{commit}</td><td>{pr}</td><td>{title}</td></tr>";
        }

        private static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
        }

        private static List<string> GetGitHistory()
        {
            var fi = new FileInfo(HistoryStore);
            if (fi.Exists)
            {
                using var fs = fi.OpenRead();
                var ser = new BinaryFormatter();
                return (List<string>)ser.Deserialize(fs);
            }
            else
            {
                Console.WriteLine($"Reading Git history in {RepoPath} from {Source} to {Target}…");
                var history = ReadGit();
                if (history == null)
                {
                    return null;
                }

                using var fs = fi.Create();
                var ser = new BinaryFormatter();
                ser.Serialize(fs, history);
                return history;
            }
        }

        private static List<string> ReadGit()
        {
            Console.WriteLine($"With git.exe {GitLogParameters}");
            var pi = new ProcessStartInfo(fileName: "git.exe", GitLogParameters)
            {
                WorkingDirectory = Repo.FullName,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var p = Process.Start(pi);

            var list = new List<string>();
            p.OutputDataReceived += (sender, e) => list.Add(e.Data);
            p.BeginOutputReadLine();
            p.WaitForExit();
            if (p.ExitCode != 0)
            {
                var stdout = p.StandardOutput.ReadToEnd();
                var stderr = p.StandardError.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Failed to read git history");
                Console.WriteLine();
                Console.Write(stderr);
                Console.WriteLine();
                return null;
            }

            //string line;
            //while ((line = p.StandardOutput.ReadLine()) != null)
            //{
            //    list.Add(line);
            //}
            return list;
        }
    }
}
