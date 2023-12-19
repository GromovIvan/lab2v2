using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2v2
{
    public sealed class NoteBook
    {
        private List<Contact> _contacts = new List<Contact>();

        public void ViewAllContacts()
        {
            Console.WriteLine("Все контакты:");

            for (int i = 0; i < _contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Имя: {_contacts[i].Name}\n   " +
                                  $"Фамилия: {_contacts[i].Surname}\n   " +
                                  $"Телефон: {_contacts[i].Phone}\n   " +
                                  $"E-mail: {_contacts[i].Email}\n");
            }
        }

        public void AddNewContact()
        {

            Contact contact = new Contact();

            Console.WriteLine("Новый контакт");
            Console.Write("Имя: ");
            contact.Name = Console.ReadLine().ToString();

            Console.Write("Фамилия: ");
            contact.Surname = Console.ReadLine().ToString();

            Console.Write("Телефон: ");
            contact.Phone = Console.ReadLine().ToString();

            Console.Write("E-mail: ");
            contact.Email = Console.ReadLine().ToString();

            _contacts.Add(contact);

            Console.WriteLine("Контакт создан.");
        }

        public void SearchContacts(int searchOption)
        {
            Console.Write("Введите запрос: ");
            string searchString = Console.ReadLine();

            Console.WriteLine("Поиск…");
            Console.WriteLine("Результаты:");

            switch (searchOption)
            {
                case 1:
                    SearchAndDisplay(contact => contact.Name.Contains(searchString));
                    break;
                case 2:
                    SearchAndDisplay(contact => contact.Surname.Contains(searchString));
                    break;
                case 3:
                    SearchAndDisplay(contact => (contact.Name + " " + contact.Surname).Contains(searchString));
                    break;
                case 4:
                    SearchAndDisplay(contact => contact.Phone.Contains(searchString));
                    break;
                case 5:
                    SearchAndDisplay(contact => contact.Email.Contains(searchString));
                    break;
                default:
                    Console.WriteLine("Некорректные данные.");
                    break;
            }
        }

        private void SearchAndDisplay(Func<Contact, bool> predicate)
        {
            int resultCount = 0;
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (predicate(_contacts[i]))
                {
                    resultCount++;
                    Console.WriteLine($"#{resultCount}  Имя: {_contacts[i].Name}\n   " +
                                        $"Фамилия: {_contacts[i].Surname}\n   " +
                                        $"Телефон: {_contacts[i].Phone}\n   " +
                                        $"E-mail: {_contacts[i].Email}\n");
                }
            }

            if (resultCount == 0)
            {
                Console.WriteLine("Ничего не найдено.");
            }
        }
    }
}
