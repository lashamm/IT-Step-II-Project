using IT_Step_II_Project.Models;
using IT_Step_II_Project.Manager;

User user = new User("", "", "");

user.UserCreate();
Console.WriteLine(user);
Console.Clear();

StudentManager studentManager = new StudentManager();
Student student = new Student();
while (true)
{
    Console.WriteLine(
      "Press A to add student. " +
    "\nPress S to show all students" +
    "\nPress F to find any student using a roll number" +
    "\nPress Q to quit the program");
char option = Console.ReadKey().KeyChar;
Console.Clear();

    if (option == 'A' || option == 'a')
    {
        studentManager.addStudent(student);
        Console.Clear();
        continue;
    }
    else if (option == 'S' || option == 's')
    {
        studentManager.showAll(student);
        Console.Clear();
        continue;
    }
    else if (option == 'F' || option == 'f')
    {
        studentManager.findStudent(student);
        Console.Clear();
        continue;
    }
    else if (option == 'Q' || option == 'q')
    {
        Environment.Exit(0);
        Console.Clear();
        continue;
    }
}

