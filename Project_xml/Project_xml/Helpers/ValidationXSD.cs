using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;

namespace XML_Format.Service
{
    public class ValidationXSD
    {
        public void Run()
        {
            string xmlFilePath = "timesheet.xml";
            string xsdFilePath = "timesheet_schema.xsd";

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, xsdFilePath);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemaSet;

            try
            {
                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    while (reader.Read()) { }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("XML документ валиден.");
                    Console.ResetColor();
                }
            }
            catch (XmlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"XML документ не валиден. Ошибка: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
