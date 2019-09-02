using KCode.ChangelogTransform.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KCode.ChangelogTransform
{
    class GitLog
    {
        private static readonly string GitExecutable = "git";
        private static readonly int HashLength = 8;

        public DirectoryInfo RepoDir { get; }
        public string SourceRef { get; }
        public string TargetRef { get; }
        public FileInfo Store { get; }

        private string GitLogParameters { get => $"log {SourceRef}..{TargetRef} --first-parent --reverse --oneline --date=short --pretty=format:%h%x09%s:%ad%x09"; }

        public GitLog(DirectoryInfo di, string fromRef, string toRef, FileInfo store)
        {
            RepoDir = di;
            SourceRef = fromRef;
            TargetRef = toRef;
            Store = store;
        }

        public List<Commit>? ReadGitHistory()
        {
            if (Store.Exists)
            {
                using var fs = Store.OpenRead();
                var ser = new BinaryFormatter();
                return (List<Commit>)ser.Deserialize(fs);
            }
            else
            {
                Console.WriteLine($"Reading Git history in {RepoDir} from {SourceRef} to {TargetRef}…");
                var history = ReadFromGit();
                if (history == null)
                {
                    return null;
                }

                using var fs = Store.Create();
                var ser = new BinaryFormatter();
                ser.Serialize(fs, history);
                return history;
            }
        }

        private List<Commit>? ReadFromGit()
        {
            Console.WriteLine($"With {GitExecutable} {GitLogParameters}");
            var pi = new ProcessStartInfo(fileName: GitExecutable, GitLogParameters)
            {
                WorkingDirectory = RepoDir.FullName,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var p = Process.Start(pi);

            var list = new List<Commit>();
            p.OutputDataReceived += (sender, e) => { if (e.Data != null) { list.Add(ParseLine(e.Data)); } };
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

            return list;
        }

        private static Commit ParseLine(string line)
        {
            var hash = line.Substring(0, HashLength);
            var title = line.Substring(HashLength + 1);
            return new Commit(hash, title);
        }
    }
}
