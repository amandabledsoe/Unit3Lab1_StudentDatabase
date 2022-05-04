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
    DisplayMainMenuOptions();
    switch (GetMenuChoice())
    {
        case 1: // info for single student
            PauseAndClearScreen();
            bool singleStudentInfo = true;
            while (singleStudentInfo)
            {
                Console.WriteLine($"Enter a number from 1 to {names.Length} to view that student's information.");
                Console.Write("Your Entry: ");
                string userEntry = Console.ReadLine();
                bool isANumber = int.TryParse(userEntry, out int userNumber);
                if (isANumber)
                {
                    if (userNumber <= names.Count() && userNumber > 0)
                    {
                        Console.WriteLine();
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
                        singleStudentInfo = WannaSeeAnotherStudent();
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
            break;
        case 2: // info for all students
            PauseAndClearScreen();
            bool allStudentInfo = true;
            while (allStudentInfo)
            {
                Console.WriteLine("The students listed in this database are:");
                Console.WriteLine();
                PrintAllStudents(names, hometown, favoriteFoods);
                PauseAndClearScreen();
                allStudentInfo = false;
            }
            break;
        case 3: // search by student name
            PauseAndClearScreen();
            Console.WriteLine("Enter a name to search for.");
            Console.Write("Your entry: ");
            string userEnteredName = Console.ReadLine();
            var result = Array.FindAll(names, element => element.Contains(userEnteredName));
            Console.WriteLine();
            if (result.Count() > 0)
            {
                Console.Write("Student names matching the entered criteria: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(userEnteredName);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine($" - {result[i]}");
                }
            }
            else
            {
                Console.WriteLine("No results matching your search have been found.");
            }
            PauseAndClearScreen();
            break;
        case 4: // exit the program
            PauseAndClearScreen();
            runningProgram = false;
            break;
        default:
            break;
    }
}
Console.WriteLine("Thank you for using the Student Database Program!");
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
        Console.WriteLine("Enter 'Y' to view another student's info, or 'N' to return to the main menu.");
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

static void PrintAllStudents(string[] names, string[] hometown, string[] favoriteFoods)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(String.Format("{0,0}{1,16}{2,25}{3,34}", "Student Number", "Student Name", "Hometown", "Favorite Food"));
    Console.ResetColor();
    for (int i = 0; i < names.Length; i++)
    {
        if (i%2!=0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(String.Format("{0,8}{1,23}{2,32}{3,34}", i + 1, names[i], hometown[i], favoriteFoods[i]));
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(String.Format("{0,8}{1,23}{2,32}{3,34}", i + 1, names[i], hometown[i], favoriteFoods[i]));
        }
    }
}

static void DisplayMainMenuOptions()
{
    Console.WriteLine("Select from the numbered options below to navigate the database:");
    Console.WriteLine();
    Console.WriteLine("\t1. View Information for a Single Student");
    Console.WriteLine("\t2. View Information for All Students");
    Console.WriteLine("\t3. Search for a Student");
    Console.WriteLine("\t4. Exit the Program");
    Console.WriteLine();
}

static int GetMenuChoice()
{
    bool gettingMenuNumber = true;
    while (gettingMenuNumber)
    {
        Console.Write("Your Number Entry: ");
        string userEntry = Console.ReadLine();
        bool isANumber = int.TryParse(userEntry, out int userNumber);
        if (isANumber)
        {
            return userNumber;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, that doesnt appear to be a number. Let's try again.");
            Console.WriteLine();
        }

    }
    return -1;
}