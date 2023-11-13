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
            // код для XPath запросов
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
    Console.Write(" ");
    int choice = Int32.Parse(Console.ReadLine());
    Console.WriteLine();
    return choice;
}