using PROXY.CASINO.Kernel;
using PROXY.CASINO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.helpers
{
    /// <summary>
    /// 
    /// </summary>
    internal static class OutputDataCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static OutputData CreateFrom( APIResponse response )
        {
            OutputData result = null;

            try
            {

                int status_code = response.StatusCode;
                String json = response.JsonBody;

                HttpQueryResult query_result = new HttpQueryResultBuilder()
                                                    .SetStatusCode( status_code )
                                                    .SetJsonContent( json )
                                                    .Build();

                result = OutputDataBuilder.BuildFrom( query_result );

            } catch( Exception ex )
            {
                result = OutputDataBuilder.BuildFrom( ex );
            }
            
            return result;
        }
    }
}
