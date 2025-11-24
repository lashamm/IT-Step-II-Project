using IT_Step_II_Project.Models;
using IT_Step_II_Project.Manager;
using System.Text.Json;


UserManager userManager = new UserManager();
userManager.UserCreate();
Console.Clear();

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
