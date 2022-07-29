using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Models
{
    public class OutputData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("proxy_result")]
        public ProxyResult ProxyResult
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("query_result")]
        public HttpQueryResult QueryResult
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        internal OutputData()
        {
        }
    }
}
