using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Models
{
    public class HttpQueryResultBuilder
    {
        public int? _StatusCode;
        public String _JsonContent;

        #region setters

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpQueryResultBuilder SetStatusCode( int value )
        {
            this._StatusCode = value;
            
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpQueryResultBuilder SetJsonContent( String value )
        {
            this._JsonContent = value;

            return this;
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpQueryResult Build()
        {
            Validation();

            HttpQueryResult result = new HttpQueryResult();

            result.JsonContent = _JsonContent;
            result.StatusCode = _StatusCode;

            Initialize();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this._JsonContent = null;
            this._StatusCode = null;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Validation()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpQueryResultBuilder()
        {
            Initialize();
        }
    }
}
