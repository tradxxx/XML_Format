﻿using System.Xml.Xsl;
using System.Xml;
using XML_Format.Service;
using Microsoft.VisualBasic;

namespace XML_Format
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите пункт:\n1) XPath-запросы к XML-документу\n2) Валидация XSD\n3) XSLT-преобразование в txt\n4) XSLT-преобразование в html\n5) Запросы к Json-документу");
            Console.Write("Ваш выбор: ");
            int value = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (value)
            {
                case 1:
                    XPath_Request();
                    break;
                case 2:
                    Validation();
                    break;
                case 3:
                    ConversionInTxt();
                    break;
                case 4:
                    ConversionInHtml();
                    break;
                case 5:
                    Json_Request(); 
                    break;
            }
            static void XPath_Request()
            {
                StarterXML starterXML = new StarterXML();

                Console.WriteLine("XML-документ");
                Console.WriteLine("Выберите пункт:\n1) Расписание текущей недели\n2) Получить все занятия на данной неделе\n3) Получить все аудитории, в которых проходят занятия.\n4) Получить все практические занятия на неделе.\n5) Получить все лекции, проводимые в указанной аудитории.\n6) Получить список всех преподавателей, проводящих практики в указанной аудитории.\n7) Получить последнее занятие для каждого дня недели.\n8) Получить общее количество занятий за всю неделю.");
                Console.Write("Ваш выбор: ");
                int value = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (value)
                {
                    case 1:
                        starterXML.ScheduleForTheCurrentWeek();
                        break;
                    case 2:
                        starterXML.AllLessons();
                        break;
                    case 3:
                        starterXML.AllRooms();
                        break;
                    case 4:
                        starterXML.AllPractice();
                        break;
                    case 5:
                        starterXML.AllLectureInRoom();
                        break;
                    case 6:
                        starterXML.AllTeachersPracticeInRoom();
                        break;
                    case 7:
                        starterXML.LastLesson();
                        break;
                    case 8:
                        starterXML.TotalCountLessons();
                        break;

                }
            }
            static void Validation()
            {
                ValidationXSD validationXSD = new ValidationXSD();
                validationXSD.Start();
            }
            static void ConversionInTxt()
            {
                XSLT_Сonversion xSLT = new XSLT_Сonversion();
                xSLT.StartTxt();
            }
            static void ConversionInHtml()
            {
                XSLT_Сonversion xSLT = new XSLT_Сonversion();
                xSLT.StartHtml();
            }


            static void Json_Request()
            {
                StarterJSON starterJSON = new StarterJSON();

                Console.WriteLine("Json-документ");
                Console.WriteLine("Выберите пункт:\n1) Расписание текущей недели\n2) Получить все занятия на данной неделе\n3) Получить все аудитории, в которых проходят занятия.\n4) Получить все практические занятия на неделе.\n5) Получить все лекции, проводимые в указанной аудитории.\n6) Получить список всех преподавателей, проводящих практики в указанной аудитории.\n7) Получить последнее занятие для каждого дня недели.\n8) Получить общее количество занятий за всю неделю.");
                Console.Write("Ваш выбор: ");
                int value = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (value)
                {
                    case 1:
                        starterJSON.ScheduleForTheCurrentWeek();
                        break;
                    case 2:
                        starterJSON.AllLessons();
                        break;
                    case 3:
                        starterJSON.AllRooms();
                        break;
                    case 4:
                        starterJSON.AllPractice();
                        break;
                    case 5:
                        starterJSON.AllLectureInRoom();
                        break;
                    case 6:
                        starterJSON.AllTeachersPracticeInRoom();
                        break;
                    case 7:
                        starterJSON.LastLesson();
                        break;
                    case 8:
                        starterJSON.TotalCountLessons();
                        break;

                }
            }
        }
    }
}