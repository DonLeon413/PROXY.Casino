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
    public class ProxyResultBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private String _Message;

        #region setters

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProxyResultBuilder SetMessage( String value )
        {
            _Message = value;
            return this;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ProxyResult Builde()
        {
            Validation();

            ProxyResult result = new ProxyResult();

            result.Message = this._Message;

            Initialize();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public static ProxyResult Ok
        {
            get
            {
                ProxyResult result = new ProxyResult();
                
                result.Message = "OK";

                return result;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this._Message = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private void Validation()
        {
            if( String.IsNullOrWhiteSpace( this._Message ) )
            {
                throw new ArgumentNullException();
            }
        }

        public ProxyResultBuilder()
        {
        }
    }
}
