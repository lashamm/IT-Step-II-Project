using IT_Step_II_Project.Models;
using IT_Step_II_Project.Manager;
using System.Text.Json;


Console.WriteLine("Welcome, press 'L' to log-in or press 'R' to Register");

bool isAuthenticated = false; 

while (!isAuthenticated) 
{
    var optionLogOrReg = char.ToUpper(Console.ReadKey().KeyChar);
    Console.Clear();
    
    if (optionLogOrReg == 'L')
    {
        bool loginSuccess = false;
        while (!loginSuccess)
        {
            Console.WriteLine("Please enter your username");
            string username = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine() ?? string.Empty;
            
            UserManager userManager = new UserManager();
            loginSuccess = userManager.UserLogin(username, password);
            
            if (!loginSuccess)
            {
                Console.WriteLine("Would you like to try again? (Y/N)");
                string retry = Console.ReadLine() ?? string.Empty;
                if (retry.ToUpper() != "Y")
                {
                    break;
                }
            }
        }
        
        if(loginSuccess)
        {
            Console.WriteLine("You are logged in");
            Console.Clear();
            isAuthenticated = true; 
        }
    }
    else if (optionLogOrReg == 'R')
    {
        UserManager userManager = new UserManager();
        userManager.UserCreate();
        Console.Clear();
        isAuthenticated = true;
    }
    else
    {
        Console.WriteLine("Invalid option. Please press 'L' to log-in or 'R' to Register");
    }
}


StudentManager studentManager = new StudentManager();

while (true)
{
    Console.WriteLine(
        "Press A to add student" +
        "\nPress S to show all students" +
        "\nPress F to find any student using a roll number" +
        "\nPress C to change a student's grade" +
        "\nPress D to delete a student" +
        "\nPress Q to quit the program");

    char option = char.ToUpper(Console.ReadKey().KeyChar);
    Console.Clear();

    switch (option)
    {
        case 'A':
            studentManager.AddStudent();
            break;
        case 'S':
            studentManager.ShowAll();
            break;
        case 'F':
            studentManager.FindStudent();
            break;
        case 'C':
            studentManager.ChangeGrade();
            break;
        case 'D':
            studentManager.DeleteStudent();
            break;
        case 'Q':
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
