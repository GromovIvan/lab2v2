namespace lab2v2
{
    internal class Program
    {
        static NoteBook notebook = new NoteBook();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                ShowMenu();
                choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        notebook.ViewAllContacts();
                        break;
                    case 2:
                        SearchOptions();
                        break;
                    case 3:
                        notebook.AddNewContact();
                        break;
                    case 4:
                        Console.WriteLine("Ождайте...");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }

            } while (choice != 4);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Посмотреть все контакты");
            Console.WriteLine("2. Поиск");
            Console.WriteLine("3. Новые контакты");
            Console.WriteLine("4. Выход");
            Console.Write("> ");
        }

        static int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
                Console.Write("> ");
            }
            return choice;
        }

        static void SearchOptions()
        {
            Console.WriteLine("Поиск по:");
            Console.WriteLine("1. Имени");
            Console.WriteLine("2. Фамилии");
            Console.WriteLine("3. Имени и фамилии");
            Console.WriteLine("4. Телефону");
            Console.WriteLine("5. По E-mail");
            Console.Write("> ");

            notebook.SearchContacts(GetUserChoice());
        }
    }
}