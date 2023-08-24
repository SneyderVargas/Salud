using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportXml
{
    public class Excel<T>
    {
        private XLWorkbook workBook;

        public Excel()
        {
            workBook = new XLWorkbook();
        }

        public void Crear(List<T> datos, string nombreHoja)
        {
            var workSheet = workBook.Worksheets.Add(nombreHoja);

            for (int fila = 1; fila <= datos.Count; fila++)
            {
                var item = datos[fila - 1];
                var properties = typeof(T).GetProperties();

                int columna = 1;
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item);
                    string valueString = Convert.ToString(value);
                    workSheet.Cell(fila, columna).Value = valueString;
                    columna++;
                }
            }
        }

        public void AgregarHoja<U>(List<U> datos, string nombreHoja)
        {
            var workSheet = workBook.Worksheets.Add(nombreHoja);

            for (int fila = 1; fila <= datos.Count; fila++)
            {
                var item = datos[fila - 1];
                var properties = typeof(U).GetProperties();

                int columna = 1;
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item);
                    string valueString = Convert.ToString(value);
                    workSheet.Cell(fila, columna).Value = valueString;
                    columna++;
                }
            }
        }

        public string ExportarBase64()
        {
            using (var memoryStream = new MemoryStream())
            {
                workBook.SaveAs(memoryStream);
                byte[] excelBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(excelBytes);
                return base64String;
            }
        }
    }
}
