using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;


using Syncfusion.Windows.Converters;
using Syncfusion.Pdf;
using Syncfusion.PdfViewer;
using Syncfusion.DocToPDFConverter;
using System.Windows;

namespace PicoCRM.Core.Moduels.Invoice
{
    public class Invoice
    {
        public void Create()
        {


            

            try

            {
                //Opens the template document
                WordDocument document = new WordDocument("Template.docx");
                string[] fieldNames = new string[] { "EmployeeId", "Name", "Phone", "City" };
                string[] fieldValues = new string[] { "1001", "Peter", "+122-2222222", "London" };
                //Performs the mail merge
              
                document.MailMerge.Execute(fieldNames,fieldValues);
                document.UpdateDocumentFields();
                //Saves and closes the WordDocument instance
                document.Save("Sample.docx", FormatType.Docx);
              
                DocToPDFConverter converter = new DocToPDFConverter();
                //Converts Word document into PDF document
                PdfDocument pdfDocument = converter.ConvertToPDF(document);
                //Saves the PDF file 
                pdfDocument.Save("WordtoPDF.pdf");

                //Closes the instance of document objects
                pdfDocument.Close(true);
                document.Close();
                //Creates an instance of the DocToPDFConverter
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }







        }
    }
     
}
