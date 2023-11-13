using XML_Format.Service;

Console.WriteLine("Выберите формат данных:");
Console.WriteLine("1 - XML");
Console.WriteLine("2 - JSON");

int format = GetUserChoice();

if (format == 1)
{
    WorkWithXml();
}
else if (format == 2)
{
    WorkWithJson();
}

static void WorkWithXml()
{
    Console.WriteLine("Выберите действие для XML:");
    Console.WriteLine("1 - XPath запросы");
    Console.WriteLine("2 - Валидация XSD");
    Console.WriteLine("3 - XSLT в TXT");
    Console.WriteLine("4 - XSLT в HTML");

    int action = GetUserChoice();

    switch (action)
    {
        case 1:
            XPath_Request();
            break;
        case 2:
            // код для валидации XSD
            break;
        case 3:
            // код для XSLT в TXT
            break;
        case 4:
            // код для XSLT в HTML
            break;
    }
}

static void WorkWithJson()
{
    // аналогично для JSON
}

static int GetUserChoice()
{
    Console.Write("Вы выбрали пункт: ");
    ConsoleKeyInfo keyInfo = Console.ReadKey();

    char input = keyInfo.KeyChar;
    int choice = int.Parse(input.ToString());
    Console.WriteLine();
    Console.WriteLine();
    return choice;
}


static void XPath_Request()
{
    DesignerXML designerXML = new DesignerXML();

    PrintMenu();

    int choice = GetUserChoice();

    switch (choice)
    {
        case 1:
            designerXML.ScheduleForTheCurrentWeek();
            break;
        case 2:
            designerXML.AllLessons();
            break;
        case 3:
            designerXML.AllRooms();
            break;
        case 4:
            designerXML.AllPractice();
            break;
        case 5:
            designerXML.AllLectureInRoom();
            break;
        case 6:
            designerXML.AllTeachersPracticeInRoom();
            break;
        case 7:
            designerXML.LastLesson();
            break;
        case 8:
            designerXML.TotalCountLessons();
            break;

    }

    Console.WriteLine();


    static void PrintMenu()
    {
        Console.WriteLine("XML-документ");
        Console.WriteLine("Выберите пункт:");
        Console.WriteLine("1) Расписание текущей недели");
        Console.WriteLine("2) Получить все занятия на данной неделе");
        Console.WriteLine("3) Получить все аудитории, в которых проходят занятия");
        Console.WriteLine("4) Получить все практические занятия на неделе");
        Console.WriteLine("5) Получить все лекции, проводимые в указанной аудитории");
        Console.WriteLine("6) Получить список всех преподавателей, проводящих практики в указанной аудитории");
        Console.WriteLine("7) Получить последнее занятие для каждого дня недели");
        Console.WriteLine("8) Получить общее количество занятий");
        
    }
}

