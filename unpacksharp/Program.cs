using System;
using System.Runtime.InteropServices;
using System.Text;

namespace unpacksharp
{
    class MainClass
    {
		[DllImport("libv8unpack4rs.so")]
	    private static extern bool parse_cf(IntPtr pFileName, IntPtr pDirName);

        public static void Main(string[] args)
        {
	        if (args.Length < 3)
	        {
		        usage();
		        Environment.Exit(-1);
	        }

	        string command = args[0];

	        if (command == "--parse")
	        {
		        string fileName = args[1];
		        string dirName = args[2];
		        
		        IntPtr pFileName = Marshal.StringToHGlobalAnsi(fileName);
                IntPtr pDirName = Marshal.StringToHGlobalAnsi(dirName);
                var result_parse = parse_cf(pFileName, pDirName);
                Console.WriteLine("parse_cf: {0}", result_parse);
	        }
	        
			//Console.ReadLine();
        }

	    private static void usage()
	    {
		    Console.WriteLine("unpacksharp --parse file_name dir_name");
	    }
    }
}
