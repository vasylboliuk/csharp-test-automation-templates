using NUnit.Framework.Constraints;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace fw_webapi_nunit.src.automation.utils
{
    public sealed class FileUtil
    {

        private FileUtil()
        {
            // default private constructor
        }

        public static string LoadFileAsString(string path)
        {
            Log.Information("Load file as String from resources: {}", path);
            string resultOutput;
            if (File.Exists(path))
            {
                // Open the file to read from.
                resultOutput = File.ReadAllText(path);
            }
            else 
            {
                string errorMsg = "Can not find the file path. File path is not valid.";
                Log.Error("Load file as String from resources: {}", path);
                throw new FileNotFoundException(errorMsg);
            }
            return resultOutput;
        }
    }
}
