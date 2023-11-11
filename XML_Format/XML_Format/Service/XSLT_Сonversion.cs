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
            string xmlFilePath = "schedule.xml";
            string xsltFilePath = "schedule_txt.xslt";
            string outputFilePath = "output.txt";

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

            xslt.Transform(xmlFilePath, outputFilePath);

            Console.WriteLine($"Преобразование завершено. Результат сохранен в {outputFilePath}");
        }

        public void StartHtml()
        {
            try
            {
                string xmlFilePath = "schedule.xml";
                string xsltFilePath = "schedule_html.xslt";
                string outputFilePath = "output.html";

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

                Console.WriteLine($"Преобразование завершено. Результат сохранен в {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
    
}
