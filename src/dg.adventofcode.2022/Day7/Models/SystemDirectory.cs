using System.Collections.Generic;
using System.Linq;

namespace dg.adventofcode._2022.Day7.Models;

public class SystemDirectory
{
    public SystemDirectory()
    {
        Directories = new List<SystemDirectory>();
        Files = new List<SystemFile>();
    }
    
    public string Name { get; set; }
    public List<SystemDirectory> Directories { get; set; } 
    public List<SystemFile> Files { get; set; }
    public SystemDirectory ParentDirectory { get; set; }

    public long GetDirectorySize()
    {
        return Files.Sum(fi => fi.Size) + Directories.Sum(d => d.GetDirectorySize());
    }

    public static SystemDirectory FindDirectory(SystemDirectory node, string name)
    {
        return node.Directories.First(d => d.Name == name);
    }
}

public class SystemFile
{
    public string Name { get; set; }
    public long Size { get; set; }
}