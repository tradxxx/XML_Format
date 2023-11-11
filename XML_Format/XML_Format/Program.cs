using System.Xml.Xsl;
using System.Xml;

namespace XML_Format
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Загружаем XML-документ
            XmlDocument doc = new XmlDocument();
            doc.Load("schedule.xml");


            // XPath запросы
            Console.WriteLine("Все занятия:");
            PrintNodeList(doc.SelectNodes("//lesson"));

            Console.WriteLine("Все аудитории:");
            PrintNodeList(doc.SelectNodes("//lesson/@room"));

            Console.WriteLine("Все практики:");
            PrintNodeList(doc.SelectNodes("//lesson[@type='practice']"));

            Console.WriteLine("Лекции в аудитории 104:");
            PrintNodeList(doc.SelectNodes("//lesson[room='104']"));

            Console.WriteLine("Преподаватели практик в аудитории 105:");
            PrintNodeList(doc.SelectNodes("//lesson[@room='105' and @type='practice']/@teacher"));

            Console.WriteLine("Последние занятия по дням:");
            PrintNodeList(doc.SelectNodes("//day/lesson[last()]"));

            int totalLessons = doc.SelectNodes("//lesson").Count;
            Console.WriteLine("Общее количество занятий: " + totalLessons);

            // XSLT преобразование
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("schedule-to-text.xslt");
            xslt.Transform("schedule.xml", "schedule.txt");

            xslt.Load("schedule-to-text.xslt");
            xslt.Transform("schedule.xml", "schedule.html");
        }

        static void PrintNodeList(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.Name == "lesson")
                {
                    Console.WriteLine($"{node.Attributes["subject"].Value} {node.Attributes["room"].Value} {node.Attributes["start"].Value} - {node.Attributes["end"].Value}");
                }
                else if (node.Name == "day")
                {
                    Console.WriteLine(node.Attributes["name"].Value);
                }
            }
            Console.WriteLine(String.Format("--", 10));
        }
    }
}