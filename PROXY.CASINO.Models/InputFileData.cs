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
    public class InputFileData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Url")]
        public String Url
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "method" )]
        public String Method
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "output_file" )]
        public String OutputFIle
        {
            get;
            internal set;
        }

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
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static InputFileData CreateFromJson( String jsonString )
        {
            InputFileData result = JsonConvert.DeserializeObject<InputFileData>( jsonString );

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        internal InputFileData()
        {
        }
    }
}
