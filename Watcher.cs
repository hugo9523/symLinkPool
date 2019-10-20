using System;
using System.IO;
using System.Security.Permissions;
using System.Security;
using System.Runtime.InteropServices;


public class Watcher
{
    public Watcher(string file_watching, string file_symlinks)
    {
        this.file_watching=file_watching;
        this.file_symlinks= file_symlinks;
    }
   string file_watching,file_symlinks;
    [DllImport("kernel32.dll")]
              public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
        static int SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1;
        static int SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE = 0x2;
        static int flag = 0x0;
     public void CreateSymLinkForFile()
    {

          string link = @"c:\bar2.txt";
            string directory = @"C:\Users\Prexun\Documents\isoTAREA.docx";
                        flag = SYMBOLIC_LINK_FLAG_DIRECTORY | SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE;
            flag = SYMBOLIC_LINK_FLAG_DIRECTORY | SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE;
            
        ;
                        CreateSymbolicLink(link, directory, 0);

    }
    public  void Run()
    {
        //string[] args = Environment.GetCommandLineArgs();

        // If a directory is not specified, exit program.
        /*if (args.Length != 2)
        {
            // Display the proper way to call the program.
            Console.WriteLine("Usage: Watcher.exe (directory)");
            return;
        }*/

        // Create a new FileSystemWatcher and set its properties.
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            watcher.Path = this.file_watching;

            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.*";

            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
    }
    string get_fileName(string pfile)
    {
        string[]path= pfile.Split(@"\");
        string mfile= path[path.Length-1];
        mfile=mfile.Split(".")[0];
        return mfile;
    }
    void CreateSymLinkForFile(string file_created)
    {
        
      
            string file_createdName= get_fileName(file_created);
          string link = file_symlinks+@"\"+ file_createdName+".txt";
            
                        flag = SYMBOLIC_LINK_FLAG_DIRECTORY | SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE;
            flag = SYMBOLIC_LINK_FLAG_DIRECTORY | SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE;
                        CreateSymbolicLink(link, file_created, 0);

    }
    // Define the event handlers.
    private  void OnChanged(object source, FileSystemEventArgs e) { 
        // Specify what is done when a file is changed, created, or deleted.
        Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        Console.WriteLine("se cambio");
        CreateSymLinkForFile(e.FullPath);
    }
    private static void OnRenamed(object source, RenamedEventArgs e) {

    
        // Specify what is done when a file is renamed.
        Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
}