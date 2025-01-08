using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InlazeAutomation.Helpers
{
    public class DataHelpers
    {
        /// <summary>
        /// Lee datos de un archivo de Excel y los devuelve como un DataTable.
        /// </summary>
        /// <param name="filePath">La ruta al archivo de Excel.</param>
        /// <param name="sheetName">El nombre de la hoja de la que leer.</param>
        /// <returns>Un DataTable que contiene los datos de Excel.</returns>
        public DataTable ReadExcelData(string filePath, string sheetName)
        {
            // Método requerido para utilizar el excel
            // Asegúrate de que la codificación sea UTF-8
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding(1252);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration() { FallbackEncoding = encoding }))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    return dataSet.Tables[sheetName];
                }
            }
        }
    }
}
