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
        public void Start()
        {
            string xmlFilePath = "schedule.xml";
            string xsdFilePath = "schedule_schema.xsd";

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
                    Console.WriteLine("XML документ валиден.");
                }
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"XML документ не валиден. Ошибка: {ex.Message}");
            }
        }
    }
}
