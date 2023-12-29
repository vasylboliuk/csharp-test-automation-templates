using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fw_webapi_nunit.src.automation.models.configuration
{
    [DataContract]
    public class EnvironmentConfigDto
    {
        [DataMember(Name = "apiUrl")]
        public string ApiUrl { get; set; }
        
        [DataMember(Name = "apiPort")]
        public int ApiPort { get; set; }

        [DataMember(Name = "apiBasePath")]
        public string ApiBasePath { get; set; }



    }
}
