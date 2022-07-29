using Newtonsoft.Json;
using PROXY.CASINO.Kernel;
using PROXY.CASINO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main( string[] args )
        {

            try
            {

                if( null != args && args.Length > 0 && false == String.IsNullOrWhiteSpace( args[ 0 ] ) )
                {

                    FileDataStorage stg = new FileDataStorage( args[ 0 ] );

                    stg.Proccess( APIResponse.QueryProcess );
                }
                else
                {
                    Console.WriteLine( "Parameter null or epty." );
                }
            } 
            catch( Exception ex )
            {
               Console.WriteLine( ex.Message );
            }

            return;

        }
    }
}
