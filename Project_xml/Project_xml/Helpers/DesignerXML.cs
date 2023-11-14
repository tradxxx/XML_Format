using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Format.Service
{
    public class DesignerXML
    {
        XmlDocument doc;
        public DesignerXML() 
        {
            doc = new XmlDocument();
            doc.Load("timesheet.xml");
        }
        public void ScheduleForTheCurrentWeek()
        {        

            Console.WriteLine("Расписание на текущую неделю:");

            XmlNodeList days = doc.SelectNodes("/timesheet/day");
            foreach (XmlNode day in days)
            {
                Console.WriteLine(day.Attributes["name"].Value);

                XmlNodeList tutorials = day.SelectNodes("tutorial");

                foreach (XmlNode tutorial in tutorials)
                {
                    Console.WriteLine($"Предмет: {tutorial.Attributes["subject"].Value}");
                    Console.WriteLine($"Аудитория: {tutorial.Attributes["room"].Value}");
                    Console.WriteLine($"Преподаватель: {tutorial.Attributes["teacher"].Value}");
                    Console.WriteLine($"Время начала: {tutorial.Attributes["start"].Value}");
                    Console.WriteLine($"Время конца: {tutorial.Attributes["end"].Value}");
                    Console.WriteLine($"Тип занятия: {tutorial.Attributes["type"].Value}");

                    Console.WriteLine();
                }
                Console.WriteLine(new string('*',10));
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        public void AllLessons()
        {                       
            XmlNodeList tutorials = doc.SelectNodes("//tutorial");

            Console.WriteLine("Все занятия на этой неделе:");

            int i = 1;

            foreach (XmlNode tutorial in tutorials)
            {

                string subject = tutorial.Attributes["subject"].Value;

                Console.WriteLine(i + ". " + subject);

                i++;

            }

            Console.ReadLine();
        }

        public void AllRooms()
        {        

            XmlNodeList rooms = doc.SelectNodes("//tutorial/room");
          
            HashSet<string> uniqueRooms = new HashSet<string>();

            foreach (XmlNode room in rooms)
            {
                uniqueRooms.Add(room.Value);
            }

            Console.WriteLine("Аудитории:");

            foreach (string room in uniqueRooms)
            {
                Console.WriteLine("* "+ room);
            }
        }

        public void AllPractice()
        {

            XmlNodeList practices = doc.SelectNodes("//tutorial[type='практика']");

            Console.WriteLine("Практики на этой неделе:");

            foreach (XmlNode tutorial in practices)
            {
                Console.WriteLine("- "+tutorial.Attributes["subject"].Value);
            }
        }

        public void AllLectureInRoom()
        {

            Console.Write("Номер аудитории: ");
            string room = Console.ReadLine();

            XmlNodeList lectures = doc.SelectNodes("//tutorial[room='" + room + "' and type='лекция']");

            Console.WriteLine("Лекции в аудитории " + room+ ":");

            if (lectures != null && lectures.Count > 0)
            {
                foreach (XmlNode tutorial in lectures)
                {
                    Console.WriteLine("* "+tutorial.Attributes["subject"].Value);
                }
            }
            else
            {
                Console.WriteLine("Лекций в данной аудитории нет");
            }

        }

        public void AllTeachersPracticeInRoom()
        {

            Console.Write("Номер аудитории: ");
            string room = Console.ReadLine();

            XmlNodeList tutorials = doc.SelectNodes($"//tutorial[room='{room}' and type='практика']");

            Console.WriteLine($"Преподаватели, проводящие практики в аудитории {room}:");

            if (tutorials != null && tutorials.Count > 0)
            {
                foreach (XmlNode tutorial in tutorials)
                {
                    string teacher = tutorial.Attributes["teacher"].Value;
                    Console.WriteLine("- "+ teacher);
                }
            }
            else
            {
                Console.WriteLine($"В данной аудитории нет практики");
            }
        }

        public void LastLesson()
        {

            XmlNodeList lastLessons = doc.SelectNodes("//day/tutorial[last()]");

            Console.WriteLine("Последнее занятие для каждого дня недели:");

            if (lastLessons != null && lastLessons.Count > 0)
            {
                foreach (XmlNode tutorial in lastLessons)
                {
                    string day = tutorial.ParentNode.Attributes["name"].Value;
                    string subject = tutorial.Attributes["subject"].Value;
                    string teacher = tutorial.Attributes["teacher"].Value;
                    string room = tutorial.Attributes["room"].Value;
                    string start = tutorial.Attributes["start"].Value;
                    string end = tutorial.Attributes["end"].Value;

                    Console.WriteLine($"{day}: {subject} ({teacher}) {room} каб. - с {start} до {end}");
                }
            }
            else
            {
                Console.WriteLine("В расписании нет занятий");
            }
        }

        public void TotalCountLessons()
        {            

            int totalLessons = GetTotalLessons(doc);

            Console.WriteLine($"Общее количество занятий за неделю: {totalLessons}");

            static int GetTotalLessons(XmlDocument doc)
            {
                // Получаем узлы всех занятий
                XmlNodeList allLessons = doc.SelectNodes("//tutorial");

                if (allLessons != null)
                {
                    return allLessons.Count;
                }

                return 0;
            }
        }
    }
}
