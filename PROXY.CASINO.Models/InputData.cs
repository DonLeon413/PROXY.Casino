using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Models
{
    
    /// <summary>
    /// 
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("headers")]
        public IEnumerable<HttpHeader> Headers
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("method")]
        public String Method
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("json_body")]
        public String JsonBody
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("url")]
        public String Url
        {
            get;
            internal set;
        }

        /// <summary>
        /// CTOR
        /// </summary>
        internal InputData()
        {
        
        }
    }
}
