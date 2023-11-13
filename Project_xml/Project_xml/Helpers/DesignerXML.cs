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

            XmlNodeList days = doc.SelectNodes("/schedule/day");
            foreach (XmlNode day in days)
            {
                Console.WriteLine(day.Attributes["name"].Value);

                XmlNodeList lessons = day.SelectNodes("lesson");

                foreach (XmlNode lesson in lessons)
                {
                    Console.WriteLine($"Предмет: {lesson.Attributes["subject"].Value}");
                    Console.WriteLine($"Аудитория: {lesson.Attributes["room"].Value}");
                    Console.WriteLine($"Преподаватель: {lesson.Attributes["teacher"].Value}");
                    Console.WriteLine($"Время начала: {lesson.Attributes["start"].Value}");
                    Console.WriteLine($"Время конца: {lesson.Attributes["end"].Value}");
                    Console.WriteLine($"Тип занятия: {lesson.Attributes["type"].Value}");

                    Console.WriteLine();
                }
                Console.WriteLine(new string('*',10));
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        public void AllLessons()
        {                       
            XmlNodeList lessons = doc.SelectNodes("//lesson");

            Console.WriteLine("Все занятия на этой неделе:");

            int i = 1;

            foreach (XmlNode lesson in lessons)
            {

                string subject = lesson.Attributes["subject"].Value;

                Console.WriteLine(i + ". " + subject);

                i++;

            }

            Console.ReadLine();
        }

        public void AllRooms()
        {        

            XmlNodeList rooms = doc.SelectNodes("//lesson/@room");
          
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

            XmlNodeList practices = doc.SelectNodes("//lesson[@type='практика']");

            Console.WriteLine("Практики на этой неделе:");

            foreach (XmlNode lesson in practices)
            {
                Console.WriteLine("- "+lesson.Attributes["subject"].Value);
            }
        }

        public void AllLectureInRoom()
        {

            Console.Write("Номер аудитории: ");
            string room = Console.ReadLine();

            XmlNodeList lectures = doc.SelectNodes("//lesson[@room='" + room + "' and @type='лекция']");

            Console.WriteLine("Лекции в аудитории " + room+ ":");

            if (lectures != null && lectures.Count > 0)
            {
                foreach (XmlNode lesson in lectures)
                {
                    Console.WriteLine("* "+lesson.Attributes["subject"].Value);
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

            XmlNodeList lessons = doc.SelectNodes($"//lesson[@room='{room}' and @type='практика']");

            Console.WriteLine($"Преподаватели, проводящие практики в аудитории {room}:");

            if (lessons != null && lessons.Count > 0)
            {
                foreach (XmlNode lesson in lessons)
                {
                    string teacher = lesson.Attributes["teacher"].Value;
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

            XmlNodeList lastLessons = doc.SelectNodes("//day/lesson[last()]");

            Console.WriteLine("Последнее занятие для каждого дня недели:");

            if (lastLessons != null && lastLessons.Count > 0)
            {
                foreach (XmlNode lesson in lastLessons)
                {
                    string day = lesson.ParentNode.Attributes["name"].Value;
                    string subject = lesson.Attributes["subject"].Value;
                    string teacher = lesson.Attributes["teacher"].Value;
                    string start = lesson.Attributes["start"].Value;
                    string end = lesson.Attributes["end"].Value;

                    Console.WriteLine($"{day}: {subject} ({teacher}) - с {start} до {end}");
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
                XmlNodeList allLessons = doc.SelectNodes("//lesson");

                if (allLessons != null)
                {
                    return allLessons.Count;
                }

                return 0;
            }
        }
    }
}
