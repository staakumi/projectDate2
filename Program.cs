using System;
using System.Collections.Generic;

namespace DiaryApp
{
    class Program
    {
        static List<Note> notes; // коллекция заметок
        static int currentIndex; // индекс текущей заметки

        static void Main(string[] args)
        {
            InitializeNotes(); // инициализация заметок
            currentIndex = 0; // начальный индекс

            while (true)
            {
                PrintMenu(); // вывод меню

                // обработка нажатий клавиш
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentIndex > 0)
                            currentIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentIndex < notes.Count - 1)
                            currentIndex++;
                        break;
                    case ConsoleKey.LeftArrow:
                        ChangeDate(-1);
                        break;
                    case ConsoleKey.RightArrow:
                        ChangeDate(1);
                        break;
                    case ConsoleKey.Enter:
                        PrintNoteDetails();
                        break;
                }

                Console.Clear();
            }
        }

        // инициализация заметок
        static void InitializeNotes()
        {
            notes = new List<Note>()
            {
                new Note("Заметка 1", "Описание заметки 1", new DateTime(2022, 6, 6), "Выполнить до 10 июня"),
                new Note("Заметка 2", "Описание заметки 2", new DateTime(2022, 6, 8), "Выполнить до 15 июня"),
                new Note("Заметка 3", "Описание заметки 3", new DateTime(2022, 6, 13), "Выполнить до 20 июня"),
                new Note("Заметка 4", "Описание заметки 4", new DateTime(2022, 6, 18), "Выполнить до 25 июня"),
                new Note("Заметка 5", "Описание заметки 5", new DateTime(2022, 6, 21), "Выполнить до 30 июня")
            };
        }

        // вывод меню
        static void PrintMenu()
        {
            Console.WriteLine("Ежедневник\n");

            for (int i = 0; i < notes.Count; i++)
            {
                if (i == currentIndex)
                    Console.Write("> ");
                else
                    Console.Write("  ");

                Console.WriteLine(notes[i].Title);
            }

            Console.WriteLine("\nИспользуйте стрелки для переключения между заметками и датами.");
            Console.WriteLine("Используйте Enter для просмотра подробной информации о заметке.");
        }

        // изменение даты
        static void ChangeDate(int direction)
        {
            notes[currentIndex].Date = notes[currentIndex].Date.AddDays(direction);
        }

        // вывод подробной информации о заметке
        static void PrintNoteDetails()
        {
            Note note = notes[currentIndex];

            Console.WriteLine($"{note.Title}\n");
            Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
            Console.WriteLine($"Выполнить до: {note.DueDate}");
            Console.WriteLine($"Описание: {note.Description}");

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню.");
            Console.ReadKey();
        }
    }

    // класс заметки
    class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string DueDate { get; set; }

        public Note(string title, string description, DateTime date, string dueDate)
        {
            Title = title;
            Description = description;
            Date = date;
            DueDate = dueDate;
        }
    }
}
