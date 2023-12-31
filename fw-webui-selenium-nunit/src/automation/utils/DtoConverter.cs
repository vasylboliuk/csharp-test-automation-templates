using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_webui_selenium_nunit.src.automation.utils
{
    public class DtoConverter
    {

        private DtoConverter() 
        {
            // defaul private constructor
        }

        public static T JsonFileToDto<T>(string filePath)
        {
            var fileOutput = FileUtil.LoadFileAsString(filePath);
            return StringToDto<T>(fileOutput);
        }

        public static T? StringToDto<T>(string value)
        {
            T result = default(T);
            try
            {
                result = JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can not deseralize data to object.");
            }
            return result;
        }
    }
}
