using System;
using System.Linq;

namespace FFCG.G5.Storage.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var storage = new FileStorage<Contact>(@"C:\TestStorage");
            while (true)
            {
                Console.WriteLine("Enter number for action... \n" +
                                  "1. Store new contact \n" +
                                  "2. View all contact \n" +
                                  "3. Delete contact");
                var input = Console.ReadLine();
                if (input == null) continue;

                switch (int.Parse(input))
                {
                    case 1:
                        StoreContact(storage);
                        break;
                    case 2:
                        ViewContacts(storage);
                        break;
                    case 3:
                        DeleteContact(storage);
                        break;
                }
            }
        }

        private static void DeleteContact(IStorage<Contact> storage)
        {
            ViewContacts(storage);
            Console.WriteLine("Number of the contact to be removed?");
            var contacts = storage.All().ToArray();
            var input = Console.ReadLine();

            if (input != null)
                storage.Delete(contacts[int.Parse(input)]);
        }

        private static void ViewContacts(IStorage<Contact> storage)
        {
            var contacts = storage.All().ToArray();
            Console.WriteLine("Contacts...");

            for (var i = 0; i < contacts.Length; i++)
                Console.WriteLine($"{i}: {contacts[i].Name}");
        }

        private static void StoreContact(IStorage<Contact> storage)
        {
            Console.WriteLine("Enter name of contact...");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
                storage.Store(new Contact(name));
        }
    }
}