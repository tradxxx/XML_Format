using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace XML_Format.Service
{
    public class XSLT_Сonversion
    {
        public void StartTxt()
        {
            string xmlFilePath = "timesheet.xml";
            string xsltFilePath = "timesheet_txt.xslt";
            string outputFilePath = "timesheetInTxt.txt";

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

            xslt.Transform(xmlFilePath, outputFilePath);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Преобразование завершено. Результат сохранен в {outputFilePath}");

            Console.ResetColor();
        }

        public void StartHtml()
        {
            try
            {
                string xmlFilePath = "timesheet.xml";
                string xsltFilePath = "timesheet_html.xslt";
                string outputFilePath = "timesheetInHtml.html";

                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(xsltFilePath);

                using (XmlReader xmlReader = XmlReader.Create(xmlFilePath))
                {
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Indent = true,
                        ConformanceLevel = ConformanceLevel.Auto // Set the ConformanceLevel to Auto
                    };

                    using (XmlWriter htmlWriter = XmlWriter.Create(outputFilePath, settings))
                    {
                        xslt.Transform(xmlReader, null, htmlWriter);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Преобразование завершено. Результат сохранен в {outputFilePath}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
    
}
