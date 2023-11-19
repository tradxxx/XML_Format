using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Format.Service
{
    public class StarterJSON
    {
        JObject scheduleJson;
        public StarterJSON() 
        {
            scheduleJson = new JObject();
            string jsonText = System.IO.File.ReadAllText("schedule.json");
            scheduleJson = JObject.Parse(jsonText);
        }
       
        public void ScheduleForTheCurrentWeek()
        {      

            Console.WriteLine("Расписание на текущую неделю:");

            foreach (var day in scheduleJson["schedule"]["day"])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(day["@name"]);
                Console.ResetColor();

                foreach (var lesson in day["lesson"])
                {
                    Console.WriteLine($"Предмет: {lesson["@subject"]}");
                    Console.WriteLine($"Аудитория: {lesson["@room"]}");
                    Console.WriteLine($"Преподаватель: {lesson["@teacher"]}");
                    Console.WriteLine($"Время начала: {lesson["@start"]}");
                    Console.WriteLine($"Время конца: {lesson["@end"]}");
                    Console.WriteLine($"Тип занятия: {lesson["@type"]}\n");
                }

                Console.WriteLine("----\n");
            }

            Console.ReadLine();
        }

        public void AllLessons()
        {
            Console.WriteLine("Все занятия на этой неделе:");

            int i = 1;

            foreach (var lesson in scheduleJson.SelectTokens("$.schedule.day[*].lesson[*]"))
            {
                string subject = lesson["@subject"].ToString();
                Console.WriteLine($"{i}. {subject}");
                i++;
            }

            Console.ReadLine();
        }

        public void AllRooms()
        {
            HashSet<string> uniqueRooms = new HashSet<string>();

            foreach (var room in scheduleJson.SelectTokens("$.schedule.day[*].lesson[*].@room"))
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
            Console.WriteLine("Практики на этой неделе:");

            foreach (var lesson in scheduleJson.SelectTokens("$.schedule.day[*].lesson[?(@.@type=='практика')]"))
            {
                Console.WriteLine($"- {lesson["@subject"]}");
            }
        }

        public void AllLectureInRoom()
        {
            Console.Write("Номер аудитории: ");
            string room = Console.ReadLine();

            Console.WriteLine($"Лекции в аудитории {room}:");

            var lectures = scheduleJson.SelectTokens($"$.schedule.day[*].lesson[?(@.@room == '{room}' && @.@type == 'лекция')]");

            if (lectures.Any())
            {
                foreach (var lecture in lectures)
                {
                    Console.WriteLine($"* {lecture["@subject"]}");
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

            Console.WriteLine($"Преподаватели, проводящие практики в аудитории {room}:");

            var lessons = scheduleJson.SelectTokens($"$.schedule.day[*].lesson[?(@.@room == '{room}' && @.@type == 'практика')]");

            if (lessons.Any())
            {
                foreach (var lesson in lessons)
                {
                    Console.WriteLine($"- {lesson["@teacher"]}");
                }
            }
            else
            {
                Console.WriteLine($"В данной аудитории нет практики");
            }
        }

        public void LastLesson()
        {
            Console.WriteLine("Последнее занятие для каждого дня недели:");

            foreach (JToken day in scheduleJson["schedule"]["day"])
            {
                JArray lessons = (JArray)day["lesson"];

                var lastLesson = lessons[lessons.Count - 1];

                Console.WriteLine(day["@name"] + ": " + lastLesson["@subject"]);
            }
        }

        public void TotalCountLessons()
        {
            int totalLessons = GetTotalLessons(scheduleJson);

            Console.WriteLine($"Общее количество занятий за неделю: {totalLessons}");

            static int GetTotalLessons(JObject schedule)
            {
                var allLessons = schedule.SelectTokens("$.schedule.day[*].lesson[*].@subject");

                return allLessons.Count();
            }
        }
    }
}
