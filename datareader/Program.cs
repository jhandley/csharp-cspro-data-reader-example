using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSPro.Dictionary;
using CSPro.Data;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace datareader
{
    class Program
    {
        static int Main(string[] args)
        {
            // Load dependent DLLs from CSPro installation directory
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver;

            return ReadCSProData(args);
        }

        static int ReadCSProData(string[] args)
        { 
            if (args.Length < 1 || args.Length > 2)
            {
                Console.Error.WriteLine("Usage: datareader datafile [dictionary]");
                return -1;
            }

            try
            {
                String dataFilePath = args[0];
                DataRepository repository = new DataRepository();
                DataDictionary dictionary = null;
                if (args.Length == 2)
                {
                    String dictionaryFilePath = args[1];
                    dictionary = new DataDictionary(dictionaryFilePath);
                }
                repository.OpenForReading(dictionary, dataFilePath);

                foreach (var key in repository.CasetainerKeys)
                {
                    var casetainer = repository.ReadCasetainer(key.positionInRepository);
                    Console.Out.WriteLine("------ {0} ------", key.key);
                    var caseData = casetainer.Case;
                    foreach (var line in caseData.CaseLines)
                    {
                        Console.Out.WriteLine(line);
                    }
                }
            } catch (Exception e)
            {
                Console.Error.WriteLine("Error: {0}", e.Message);
                return -1;
            }

            return 0;
        }
        
        private static Assembly AssemblyResolver(object sender, ResolveEventArgs args)
        {
            string csproDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "CSPro 7.1");
            string dllFilename = Path.Combine(csproDirectory, new AssemblyName(args.Name).Name + ".dll");
            return File.Exists(dllFilename) ? Assembly.LoadFrom(dllFilename) : null;
        }
    }
}
