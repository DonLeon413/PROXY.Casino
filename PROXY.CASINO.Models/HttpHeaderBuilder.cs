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
    public class HttpHeaderBuilder
    {
        private String _Name;
        private String _Value;

        #region setters

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpHeaderBuilder SetName( String value )
        {
            this._Name = value;
            
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpHeaderBuilder SetValue( String value )
        {
            this._Value = value;

            return this;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpHeader Build()
        {
            Validation();

            HttpHeader result = new HttpHeader();

            result.Name = this._Name;
            result.Value = ( String.IsNullOrEmpty( this._Value ) ? "" : this._Value );

            Initialize();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this._Name = null;
            this._Value = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void Validation()
        {
            if( String.IsNullOrWhiteSpace( this._Name ) )
            {
                throw new ArgumentException( "Header name is empty or null." );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static HttpHeaderBuilder Init()
        {
            return new HttpHeaderBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpHeaderBuilder()
        {
        }
    }
}
