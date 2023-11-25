#!/usr/bin/env dotnet-script
#r "nuget: Microsoft.CodeAnalysis.CSharp, 4.7.0"
#r "nuget: HedgeModManager.CodeCompiler, 0.2.37"

using HedgeModManager.CodeCompiler;
var StartDirectory = Environment.CurrentDirectory;
var TestOnly = false;
var Failures = new List<string>();

Environment.CurrentDirectory = Path.Combine(StartDirectory, "Source");

foreach(var arg in Args)
{
    if (arg.Equals("test", StringComparison.OrdinalIgnoreCase))
    {
        TestOnly = true;
    }
}

await BuildAllFolders(".");

if (Failures.Count != 0)
{
    Console.WriteLine("Failed builds:");
    foreach(var fail in Failures)
    {
        Console.WriteLine($"- {fail}");
    }

    Environment.Exit(1);
}

async Task BuildAllFolders(string root)
{
    foreach(var dir in Directory.EnumerateDirectories(root))
    {
        await BuildFolder(dir);
        Console.WriteLine();
    }
}

async Task BuildFolder(string path, bool test = true)
{
    if (TestOnly)
    {
        test = true;
    }

    var name = Path.GetFileName(path);
    Console.WriteLine($"Building {name}");

    var system = new BuildSystem();
    if (!string.Equals(Path.GetFileName(path), "Globals", StringComparison.OrdinalIgnoreCase))
    {
        system.AddFolder("Globals");
    }
    
    system.AddFolder(path);

    var result = system.Build();
    var failed = false;
    if (test)
    {
        Console.WriteLine($"Testing {name}");
        Console.WriteLine("Detected codes:");

        var codes = CodeFile.FromText(result);
        foreach(var code in codes)
        {
            Console.WriteLine($"- {code.Name}");
        }
        var options = new CompilerOptions<CodeFile>(codes)
        {
            IncludeResolver = codes,
            IncludeAllSources = true
        };

        var report = await CodeProvider.CompileCodes(options);
        failed = report.HasErrors;

        if (report.Blocks.Count != 0)
        {
            Console.WriteLine("Build Logs:");
            foreach(var block in report.Blocks)
            {
                Console.WriteLine($"{block.Key}:");
                foreach(var message in block.Value)
                {
                    Console.WriteLine($"\t{message.ToString()}");
                }
            
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
    
    if (failed)
    {
        Console.WriteLine($"{name} Checks failed");
        Failures.Add(name);
    }
    else
    {
        Console.WriteLine($"{name} built successfully");
        if (!TestOnly)
        {
            var outPath = Path.Combine(StartDirectory, "build", $"{Path.GetFileName(path).Replace(" ", string.Empty)}.hmm");
            Directory.CreateDirectory(Path.GetDirectoryName(outPath));
            File.WriteAllText(outPath, result);
        }
    }
}

public class BuildSystem
{
    public List<Action<StringBuilder>> BuildActions { get; } = new List<Action<StringBuilder>>();
    
    public void AddText(string text)
    {
        BuildActions.Add(x => x.Append(text));
    }
    
    public void AddFile(string path)
    {
        var fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath))
        {
            return;
        }

        BuildActions.Add(x => x.AppendLine(File.ReadAllText(fullPath)));
    }

    public void AddFolder(string path, string filter = "*.hmm")
    {
        var fullPath = Path.GetFullPath(path);
        if (!Directory.Exists(fullPath))
        {
            return;
        }

        BuildActions.Add(x => 
        {
            foreach(var file in Directory.EnumerateFiles(fullPath, filter, SearchOption.AllDirectories))
            {
                x.AppendLine(File.ReadAllText(file));
            }
        });
    }

    public string Build()
    {
        var builder = new StringBuilder();
        
        foreach(var action in BuildActions)
        {
            action(builder);
        }

        return builder.ToString();
    }
}
