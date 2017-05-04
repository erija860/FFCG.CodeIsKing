using System.IO;
using NUnit.Framework;

namespace FFCG.G5.Storage.Tests
{
    public class StorageTestBase
    {
        protected Contact Contact;
        protected IStorage<Contact> Storage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Storage = new FileStorage<Contact>(@"C:\TestStorage");
            Contact = new Contact("Erik Jansson");
            Storage.Store(Contact);
        }

        [TearDown]
        public void Dispose()
        {
            Directory.Delete(@"C:\TestStorage", true);
        }
    }
}