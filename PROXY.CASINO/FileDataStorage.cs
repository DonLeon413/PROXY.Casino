using Newtonsoft.Json;
using PROXY.CASINO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROXY.CASINO
{
    public class FileDataStorage
    {
        private String _SourceFIleName;
        private InputFileData _FileData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueryProcessor"></param>
        public void Proccess( Func<InputData, OutputData > QueryProcessor )
        {
            OutputData output_data = null;
            try
            {
                Initialize();

                InputData input_data = new InputDataBuilder()
                                                .SetUrl( this._FileData.Url )
                                                .SetMethod( this._FileData.Method )
                                                .AddHeaders( this._FileData.Headers )
                                                .Builde();

                output_data = QueryProcessor( input_data );

            } catch( Exception ex )
            {
                output_data = OutputDataBuilder.BuildFrom( ex );
            }

            SaveOutputData( output_data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void Initialize()
        {

            using( StreamReader stream_reader = new StreamReader( this._SourceFIleName) )
            {
                String json_str = stream_reader.ReadToEndAsync().Result;

                this._FileData = InputFileData.CreateFromJson( json_str );                                
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void SaveOutputData( OutputData data )
        {
            String json_str = JsonConvert.SerializeObject( data );

            if( null != this._FileData )
            {
                String file_name = this._FileData.OutputFIle;
                if( String.IsNullOrWhiteSpace( file_name ) )
                {
                    file_name = this._SourceFIleName;
                }

                File.WriteAllText( file_name, json_str );
            }        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFIleName"></param>
        /// <exception cref="ArgumentException"></exception>
        public FileDataStorage( String sourceFIleName )
        {
            if( string.IsNullOrWhiteSpace( sourceFIleName ) )
            {
                throw new ArgumentException( $"'{nameof( sourceFIleName )}' cannot be null or whitespace.", nameof( sourceFIleName ) );
            }

            this._SourceFIleName = sourceFIleName;
        }
    }
}
