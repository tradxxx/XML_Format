using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Format.Service
{
    public class DesignerJSON
    {
        JObject timesheetJson;
        public DesignerJSON() 
        {
            timesheetJson = new JObject();
            string jsonText = System.IO.File.ReadAllText("timesheet.json");
            timesheetJson = JObject.Parse(jsonText);
        }
       
        public void ScheduleForTheCurrentWeek()
        {      

            Console.WriteLine("Расписание:");

            foreach (var day in timesheetJson["timesheet"]["day"])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(day["name"]);
                Console.ResetColor();

                foreach (var tutorial in day["tutorial"])
                {
                    Console.WriteLine($"Предмет: {tutorial["subject"]}");
                    Console.WriteLine($"Аудитория: {tutorial["room"]}");
                    Console.WriteLine($"Преподаватель: {tutorial["teacher"]}");
                    Console.WriteLine($"Время начала: {tutorial["start"]}");
                    Console.WriteLine($"Время конца: {tutorial["end"]}");
                    Console.WriteLine($"Тип занятия: {tutorial["type"]}\n");
                }

                Console.WriteLine("----\n");
            }

            Console.ReadLine();
        }

        public void AllLessons()
        {
            Console.WriteLine("Все занятия:");

            int i = 1;

            foreach (var tutorial in timesheetJson.SelectTokens("$.timesheet.day[*].tutorial[*]"))
            {
                string subject = tutorial["subject"].ToString();
                Console.WriteLine($"{i}. {subject}");
                i++;
            }

            Console.ReadLine();
        }

        public void AllRooms()
        {
            HashSet<string> uniqueRooms = new HashSet<string>();

            foreach (var room in timesheetJson.SelectTokens("$.timesheet.day[*].tutorial[*].room"))
            {
                uniqueRooms.Add(room.ToString());
            }

            Console.WriteLine("Аудитории:");

            foreach (string room in uniqueRooms)
            {
                Console.WriteLine($"* {room}");
            }
        }

        public void AllPractice()
        {
            Console.WriteLine("Все практики:");

            foreach (var tutorial in timesheetJson.SelectTokens("$.timesheet.day[*].tutorial[?(@.type=='практика')]"))
            {
                Console.WriteLine($"- {tutorial["subject"]}");
            }
        }

        public void AllLectureInRoom()
        {
            Console.Write("Номер аудитории: ");
            string room = Console.ReadLine();

            Console.WriteLine($"Лекции в аудитории {room}:");

            var lectures = timesheetJson.SelectTokens($"$.timesheet.day[*].tutorial[?(@.room == '{room}' && @.type == 'лекция')]");

            if (lectures.Any())
            {
                foreach (var lecture in lectures)
                {
                    Console.WriteLine($"* {lecture["subject"]}");
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

            Console.WriteLine($"Преподаватели, проводящие практики в аудитории номер {room}:");

            var tutorials = timesheetJson.SelectTokens($"$.timesheet.day[*].tutorial[?(@.room == '{room}' && @.type == 'практика')]");

            if (tutorials.Any())
            {
                foreach (var tutorial in tutorials)
                {
                    Console.WriteLine($"- {tutorial["teacher"]}");
                }
            }
            else
            {
                Console.WriteLine($"В данной аудитории нет практики");
            }
        }

        public void LastLesson()
        {
            Console.WriteLine("Последние занятия:");

            foreach (JToken day in timesheetJson["timesheet"]["day"])
            {
                JArray tutorials = (JArray)day["tutorial"];

                var lastLesson = tutorials[tutorials.Count - 1];

                Console.WriteLine(day["name"] + ": " + lastLesson["subject"]);
            }
        }

        public void TotalCountLessons()
        {
            int totalLessons = GetTotalLessons(timesheetJson);

            Console.WriteLine($"Общее количество занятий: {totalLessons}");

            static int GetTotalLessons(JObject timesheet)
            {
                var allLessons = timesheet.SelectTokens("$.timesheet.day[*].tutorial[*].subject");

                return allLessons.Count();
            }
        }
    }
}
