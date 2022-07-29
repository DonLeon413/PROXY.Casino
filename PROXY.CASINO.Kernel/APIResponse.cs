using PROXY.CASINO.Kernel.helpers;
using PROXY.CASINO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Kernel
{
    public class APIResponse
    {
        private HttpResponseMessage _ResponseMessage;

        /// <summary>
        /// 
        /// </summary>
        public int StatusCode
        {
            get
            {
                return (int)this._ResponseMessage.StatusCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public String JsonBody
        {
            get
            {
                String result = null;

                result = this._ResponseMessage?.Content?.ReadAsStringAsync().Result;
                
                return result;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsJsonBody
        {
            get
            {
                try
                {
                    String contentType = this._ResponseMessage?.Content?.Headers?.GetValues( "Content-Type" ).First();

                    return true;

                } catch( Exception ex )
                {

                }
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static APIResponse Request( InputData data )
        {
            using( HttpRequestMessage request_message = new HttpRequestMessage() )
            {
                // Set url
                request_message.RequestUri = new Uri( data.Url );

                // Set method
                request_message.Method = new HttpMethod( data.Method );
                
                // Add headers
                foreach( HttpHeader header in data.Headers )
                {
                    request_message.Headers.Add( header.Name, header.Value );
                }

                // add json body
                if( false == String.IsNullOrWhiteSpace( data.JsonBody ) )
                {
                    request_message.Content = new StringContent( data.JsonBody, Encoding.UTF8, "application/json" );
                }

                using( HttpClient http_client = new HttpClient() )
                {
                    HttpResponseMessage response_message = http_client.SendAsync( request_message ).Result;

                    APIResponse result = new APIResponse( response_message );

                    return result;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static OutputData QueryProcess( InputData data )
        {            

            APIResponse response = APIResponse.Request( data );

            OutputData result = OutputDataCreator.CreateFrom( response );
            
            return result;
        }

        /// <summary>
        /// CTOR
        /// </summary>
        private APIResponse( HttpResponseMessage responseMessage )
        {
            this._ResponseMessage = responseMessage ?? throw new ArgumentNullException( nameof( responseMessage ) );
        }
    }
}
