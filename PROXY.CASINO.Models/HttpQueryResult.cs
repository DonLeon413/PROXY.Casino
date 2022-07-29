using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpQueryResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status_code")]
        public int? StatusCode
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "json_content" )]
        public String JsonContent
        {
            get;
            internal set;
        }

        /// <summary>
        /// CTOR
        /// </summary>
        internal HttpQueryResult()
        {
        }
    }
}
