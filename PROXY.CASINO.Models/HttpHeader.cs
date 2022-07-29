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
    public class HttpHeader
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "name" )]
        public String Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value")]
        public String Value
        {
            get;
            internal set;
        }

        /// <summary>
        /// CTOR
        /// </summary>
        internal HttpHeader()
        {
        }
    }
}
