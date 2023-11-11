using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace XML_Format.Service
{
    public class XSLT_Сonversion
    {
        public void Start()
        {
            string xmlFilePath = "schedule.xml";
            string xsltFilePath = "schedule.xslt";
            string outputFilePath = "output.txt";

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

            xslt.Transform(xmlFilePath, outputFilePath);

            Console.WriteLine($"Преобразование завершено. Результат сохранен в {outputFilePath}");
        }
    }
    
}
