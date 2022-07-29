using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO.Models
{
    public class InputDataBuilder
    {
        private String _Url;
        private String _Method;
        private String _JsonBody;
        private List<HttpHeader> _Headers;

        private static List<String> availableMethods = new List<string>() { "Get", "Put", "Post", "Delete" };

        #region setters

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InputDataBuilder AddHeader( HttpHeader value )
        {
            this._Headers.Add( value );
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public InputDataBuilder AddHeaders( IEnumerable<HttpHeader> values )
        {
            foreach( HttpHeader header in values )
            {
                this._Headers.Add( header );
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InputDataBuilder SetUrl( String value )
        {
            this._Url = value;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InputDataBuilder SetMethod( String value )
        {
            _Method = value;

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InputDataBuilder SetJsonBody( String value )
        {
            this._JsonBody = value;

            return this;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public InputData Builde()
        {
            Validation();

            InputData result = new InputData();

            result.JsonBody = this._JsonBody;
            result.Url = this._Url;
            result.Method = this._Method;
            result.Headers = this._Headers;

            Initialize();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void Validation()
        {
            if( String.IsNullOrWhiteSpace( this._Method ) )
            {
                throw new ArgumentException( "Method is empty or null." );
            }

            if( null == availableMethods.Where( i => 0 == String.Compare( i, this._Method, true ) ).FirstOrDefault() )
            {
                throw new ArgumentException( $"Method '{this._Method}' is unknown." );
            }

            if( String.IsNullOrWhiteSpace( this._Url ) )
            {
                throw new ArgumentException( "Url is null or empty." );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this._JsonBody = null;
            this._Url = null;
            this._Method = null;
            this._Headers = new List<HttpHeader>();
        }

        public InputDataBuilder()
        {
            Initialize();
        }
    }
}
