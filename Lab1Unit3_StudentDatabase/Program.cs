string[] names = new string[]
{
    "Zach Morris",
    "Kelly Kapowski",
    "Jessie Spannow",
    "AC Slater",
    "Lisa Turtle",
    "Screech Powers"
};
string[] hometown = new string[]
{
    "Pacific Palisades, California",
    "Santa Monica, California",
    "Pacific Palisades, California",
    "Philadelphia, Pennsylvania",
    "Beverly Hills, California",
    "Brentwood, California"
};
string[] favoriteFoods = new string[]
{
    "Cheeseburgers",
    "Salads",
    "Chicken Tenders",
    "Cheese Steak Sandwiches",
    "Fruit Salad",
    "Chocolate-Covered Grasshoppers"
};
bool runningProgram = true;

Console.WriteLine("Welcome to the Student Database Program!");
PauseAndClearScreen();
while (runningProgram)
{
    Console.WriteLine("Enter a Student number from 1 to 6 to view their name, hometown, and favorite food.");
    Console.Write("Your Entry: ");
    string userEntry = Console.ReadLine();
    bool isANumber = int.TryParse(userEntry, out int userNumber);
    if (isANumber)
    {
        if (userNumber <= names.Count() && userNumber > 0)
        {
            PauseAndClearScreen();
            PrintStudentName(names, userNumber);

            bool displayingInformation = true;
            while (displayingInformation)
            {
                Console.WriteLine("What information would you like to learn about this student?");
                Console.WriteLine("You can choose 'Hometown' or 'Favorite Food'. Enter 'H' or 'F' below.");
                Console.Write("Your Category Choice: ");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice == "h")
                {
                    DisplayHometown(names, userNumber, hometown);
                    PauseAndClearScreen();
                    displayingInformation = false;
                }
                else if (userChoice == "f")
                {
                    DisplayFavoriteFood(names, userNumber, favoriteFoods);
                    PauseAndClearScreen();
                    displayingInformation = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, I dont understand that choice. Let's try again.");
                    Console.WriteLine();
                }
            }
            runningProgram = WannaSeeAnotherStudent();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, that number appears to be out of range. Please try again.");
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Sorry, that doesnt appear to be a number. Let's try again.");
        Console.WriteLine();
    }
}
Console.WriteLine("Thank you for using the Staudent Database Program!");
Console.WriteLine("Goodbye...");

static void PauseAndClearScreen()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to Continue.");
    Console.ReadLine();
    Console.Clear();
}
static bool WannaSeeAnotherStudent()
{
    bool askingThisUser = true;
    while (askingThisUser)
    {
        Console.WriteLine("Would you like to view information for another student?");
        Console.WriteLine("Enter 'Y' to view another student's info, or 'N' to end the program.");
        Console.Write("Your Choice: ");
        string userChoice = Console.ReadLine().ToLower();
        if (userChoice == "y")
        {
            PauseAndClearScreen();
            return true;
        }
        else if (userChoice == "n")
        {
            PauseAndClearScreen();
            return false;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, I don't understand that response. Let's try again.");
            Console.WriteLine();
        }
    }
    return false;
}
static void DisplayHometown(string[] names, int userNumber, string[] hometowns)
{
    Console.WriteLine();
    Console.Write($"The hometown of student ");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write($"{names[userNumber - 1]} ");
    Console.ResetColor();
    Console.Write("is ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"{hometowns[userNumber - 1]}");
    Console.ResetColor();
    Console.Write(".");
    Console.WriteLine();
}
static void DisplayFavoriteFood(string[] names, int userNumber, string[] favoriteFoods)
{
    Console.WriteLine();
    Console.Write($"The favorite food of student ");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write($"{names[userNumber - 1]} ");
    Console.ResetColor();
    Console.Write("is ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"{favoriteFoods[userNumber - 1]}");
    Console.ResetColor();
    Console.Write(".");
    Console.WriteLine();
}
static void PrintStudentName(string[] names, int userNumber)
{
    Console.Write($"Student #{userNumber} is ");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write($"{names[userNumber - 1]}");
    Console.ResetColor();
    Console.Write(".");
    Console.WriteLine();
    Console.WriteLine();
}