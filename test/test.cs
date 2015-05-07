using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace test
{
    class Program
    {

        static IEnumerable<Result> CSharp()
        {
            List<Result> results = new List<Result>();
            results.AddRange(Exec("..", "%CSC%", "/nologo /out:bin/csharp.exe code\\main.cs code\\code.cs"));
            results.AddRange(Exec("..\\bin", "..\\bin\\csharp.exe", ""));
            return results;
        }

        static IEnumerable<Result> FSharp()
        {
            List<Result> results = new List<Result>();
            results.AddRange(Exec("..", "%FSC%", "/nologo --target:exe /out:bin/fsharp.exe code\\code.fs code\\main.fs"));
            results.AddRange(Exec("..\\bin", "..\\bin\\fsharp.exe", ""));
            return results;
        }


        static AutoResetEvent needsBuild = new AutoResetEvent(true);
        static void Main(string[] args)
        {
            WatchForChanges();
            while (true)
            {
                needsBuild.WaitOne();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Executing Test...");
                Console.ResetColor();
                ClearBuild();
                var results = CollectMany(new Func<IEnumerable<Result>>[] {
                    CSharp,
                    FSharp
                });

                PrintResults(results.Result);
            }
        }
        static void PrintResults(IEnumerable<Result> results)
        {
            Console.Clear();
            foreach (var result in results)
            {
                switch (result.Type)
                {
                    case ResultType.Pass:
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("PASS");
                        Console.ResetColor();
                        Console.Write("] ");
                        Console.WriteLine(result.Text);
                        break;
                    case ResultType.Fail:
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("FAIL");
                        Console.ResetColor();
                        Console.Write("] ");
                        Console.WriteLine(result.Text);
                        break;
                    case ResultType.StdErr:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(result.Text);
                        Console.ResetColor();
                        break;
                    case ResultType.StdOut:
                        Console.WriteLine(result.Text);
                        break;
                }
            }
        }
        private static async Task<IEnumerable<T>> CollectMany<T>(Func<IEnumerable<T>>[] funcs)
        {
            var tasks = new Task<IEnumerable<T>>[funcs.Length];
            for (var i = 0; i < funcs.Length; i++)
            {
                ((Action<int>) (x => {
                    tasks[i] = Task.Run<IEnumerable<T>>((() => funcs[x]()));
                }))(i);
            }
            var allResults = await Task.WhenAll(tasks);
            List<T> ret = new List<T>();
            foreach (var results in allResults)
            {
                ret.AddRange(results);
            }
            return ret;
        }
        static void WatchForChanges()
        {
            var watcher = new FileSystemWatcher("../code", "*");
            watcher.Changed += watcher_Changed;
            watcher.Renamed += watcher_Changed;
            watcher.Created += watcher_Changed;
            watcher.Deleted += watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }

        static void ClearBuild()
        {
            if (!Directory.Exists("../bin")) Directory.CreateDirectory("../bin");
            foreach (var file in Directory.GetFiles("../bin")) File.Delete(file);
        }


        static IEnumerable<Result> Exec(string dir, string cmd, string args)
        {
            List<Result> results = new List<Result>();
            var filename = Environment.ExpandEnvironmentVariables(cmd);
            if (File.Exists(filename))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
					WorkingDirectory = dir,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    FileName = filename,
                    Arguments = args
                };
                Process proc = Process.Start(psi);
                proc.OutputDataReceived += (o, e) =>
                {
                    if (e.Data != null)
                    {
                        string[] words = e.Data.Split(new char[] { ':' }, 2);
                        if (words.Length == 2 && words[0] == "PASS")
                        {
                            results.Add(new Result
                            {
                                Type = ResultType.Pass,
                                Text = words[1]
                            });
                        }
                        else if (words.Length == 2 && words[0] == "FAIL")
                        {
                            results.Add(new Result
                            {
                                Type = ResultType.Fail,
                                Text = words[1]
                            });
                        }
                        else
                        {
                            results.Add(new Result
                            {
                                Type = ResultType.StdOut,
                                Text = e.Data
                            });
                        }
                    }
                };
                proc.ErrorDataReceived += (o, e) =>
                {
                    if (e.Data != null)
                    {
                        results.Add(new Result
                        {
                            Type = ResultType.StdErr,
                            Text = e.Data
                        });
                    }
                };

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                proc.WaitForExit(2000);

                if (!proc.HasExited)
                {
                    proc.Kill();
                    results.Add(new Result
                    {
                        Type = ResultType.Fail,
                        Text = String.Format("{0} failed to execute within 2000ms.", filename)
                    });
                } else {
                    Thread.Sleep(100);
                }
            }
            return results;
        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            needsBuild.Set();
        }
    }

    public enum ResultType {
        StdOut,
        StdErr,
        Pass,
        Fail
    }

    class Result {
        public ResultType Type;
        public string Text;
    }
}
