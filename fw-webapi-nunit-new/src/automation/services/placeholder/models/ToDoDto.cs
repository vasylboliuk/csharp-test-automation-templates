using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fw_webapi_nunit.src.automation.models.configuration
{
    [DataContract]
    public class ToDoDto
    {
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
        
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
        
        [DataMember(Name = "completed")]
        public string Completed { get; set; }

    }
    
}
