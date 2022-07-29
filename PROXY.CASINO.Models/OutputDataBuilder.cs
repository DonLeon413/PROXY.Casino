using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Models
{
    public class OutputDataBuilder
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static OutputData BuildFrom( Exception ex )
        {
            OutputData result = new OutputData();

            result.ProxyResult = new ProxyResultBuilder()
                                        .SetMessage( ex.Message )
                                        .Builde();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static OutputData BuildFrom( HttpQueryResult data )
        {
            OutputData result = new OutputData();

            result.QueryResult = data;

            result.ProxyResult = ProxyResultBuilder.Ok;

            return result;
        }
    }
}
