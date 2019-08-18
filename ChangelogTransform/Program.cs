using KCode.ChangelogTransform.Writers;
using System;
using System.IO;

namespace KCode.ChangelogTransform
{
    class Program
    {
        private static readonly string Source = "1.2.19";
        private static readonly string Target = "1.3.0-rc2";
        private static readonly string RepoPath = @"C:\dev\mumble\mumble\mumble\";

        private static readonly string HistoryStore = "Store_History";


        static void Main(string[] args)
        {
            Console.Title = "Changelog Transform";

            var gitLog = new GitLog(new DirectoryInfo(RepoPath), Source, Target, new FileInfo(HistoryStore));
            var history = gitLog.ReadGitHistory();
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

            var linearWriter = new LinearHistoryWriter("history-linear.html");
            linearWriter.Write(history);

            var groupWriter = new CategoryHistoryWriter("history-grouped.html");
            groupWriter.Write(history);

            //Console.WriteLine("ENTER to exit");
            //Console.ReadLine();
        }

        private static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
        }
    }
}
