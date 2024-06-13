using Spectre.Console;
using System;
using System.Collections.Generic;

namespace SchoolManagement
{
    public enum ClassLevel
    {
        Class1, Class2, Class3, Class4, Class5, Class6, Class7, Class8, Class9, Class10, Class11, Class12
    }

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Student
    {
        public string Name { get; }
        public int Id { get; }
        public ClassLevel Class { get; }
        public double Percentage { get; set; }
        public Grade Grade { get; set; }

        public Student(string name, int id, ClassLevel classLevel, double percentage, Grade grade)
        {
            Name = name;
            Id = id;
            Class = classLevel;
            Percentage = percentage;
            Grade = grade;
        }

        public void DisplayStudentInfo()
        {
            AnsiConsole.MarkupLine($"[bold blue]Student Name:[/] [blue]{Name}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Student ID:[/] [blue]{Id}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Class:[/] [blue]{Class}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Percentage:[/] [blue]{Percentage}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Grade:[/] [blue]{Grade}[/]");
        }
    }

    public class Teacher
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Student> Students { get; }

        public Teacher(string name, int id)
        {
            Name = name;
            Id = id;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void DisplayTeacherInfo()
        {
            AnsiConsole.MarkupLine($"[bold green]Teacher Name:[/] [green]{Name}[/]");
            AnsiConsole.MarkupLine($"[bold green]Teacher ID:[/] [green]{Id}[/]");
            AnsiConsole.MarkupLine("[bold green]Students:[/]");

            foreach (var student in Students)
            {
                student.DisplayStudentInfo();
                AnsiConsole.WriteLine();
            }
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            while (true)
            {
                AnsiConsole.MarkupLine("[bold]Choose an option:[/]");
                AnsiConsole.MarkupLine("[bold]1.[/] Enter Student Data");
                AnsiConsole.MarkupLine("[bold]2.[/] Enter Teacher Data");
                AnsiConsole.MarkupLine("[bold]3.[/] Display Student Data");
                AnsiConsole.MarkupLine("[bold]4.[/] Display Teacher Data");
                AnsiConsole.MarkupLine("[bold]5.[/] Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnterStudentData();
                        break;
                    case "2":
                        EnterTeacherData();
                        break;
                    case "3":
                        DisplayStudentData();
                        break;
                    case "4":
                        DisplayTeacherData();
                        break;
                    case "5":
                        return;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Invalid choice, please try again.[/]");
                        break;
                }
            }
        }

        static void EnterStudentData()
        {
            AnsiConsole.MarkupLine("[bold]Enter Student Data:[/]");

            AnsiConsole.Markup("[blue]Name:[/] ");
            string name = Console.ReadLine();

            AnsiConsole.Markup("[blue]ID:[/] ");
            int id = int.Parse(Console.ReadLine());

            AnsiConsole.Markup("[blue]Class (Class1, Class2, ..., Class12):[/] ");
            ClassLevel classLevel = (ClassLevel)Enum.Parse(typeof(ClassLevel), Console.ReadLine());

            AnsiConsole.Markup("[blue]Percentage:[/] ");
            double percentage = double.Parse(Console.ReadLine());

            AnsiConsole.Markup("[blue]Grade (A, B, C, D, F):[/] ");
            Grade grade = (Grade)Enum.Parse(typeof(Grade), Console.ReadLine());

            students.Add(new Student(name, id, classLevel, percentage, grade));

            AnsiConsole.MarkupLine("[bold]Entered Student Data:[/]");
            AnsiConsole.MarkupLine($"[bold blue]Name:[/] [blue]{name}[/]");
            AnsiConsole.MarkupLine($"[bold blue]ID:[/] [blue]{id}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Class:[/] [blue]{classLevel}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Percentage:[/] [blue]{percentage}[/]");
            AnsiConsole.MarkupLine($"[bold blue]Grade:[/] [blue]{grade}[/]");
            AnsiConsole.WriteLine();
        }

        static void EnterTeacherData()
        {
            AnsiConsole.MarkupLine("[bold]Enter Teacher Data:[/]");

            AnsiConsole.Markup("[green]Name:[/] ");
            string name = Console.ReadLine();

            AnsiConsole.Markup("[green]ID:[/] ");
            int id = int.Parse(Console.ReadLine());

            teachers.Add(new Teacher(name, id));

            AnsiConsole.MarkupLine("[bold]Entered Teacher Data:[/]");
            AnsiConsole.MarkupLine($"[bold green]Name:[/] [green]{name}[/]");
            AnsiConsole.MarkupLine($"[bold green]ID:[/] [green]{id}[/]");
            AnsiConsole.WriteLine();
        }

        static void DisplayStudentData()
        {
            AnsiConsole.MarkupLine("[bold]Student Data:[/]");
            foreach (var student in students)
            {
                student.DisplayStudentInfo();
                AnsiConsole.WriteLine();
            }
        }

        static void DisplayTeacherData()
        {
            AnsiConsole.MarkupLine("[bold]Teacher Data:[/]");
            foreach (var teacher in teachers)
            {
                teacher.DisplayTeacherInfo();
                AnsiConsole.WriteLine();
            }
        }
    }
}