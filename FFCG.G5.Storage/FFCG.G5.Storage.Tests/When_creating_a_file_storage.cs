using System.IO;
using System.Linq;
using FluentAssertions;
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

    [TestFixture]
    public class When_creating_a_file_storage : StorageTestBase
    {
        [Test]
        public void Should_create_correct_folder_path()
        {
            DirectoryAssert.Exists(@"C:\TestStorage\Contacts");
        }
    }

    [TestFixture]
    public class When_storing_a_contact : StorageTestBase
    {
        [Test]
        public void Should_create_file()
        {
            File.Exists($@"C:\TestStorage\Contacts\{Contact.Id}").Should().Be(true);
        }
    }

    [TestFixture]
    public class When_deleting_a_contact : StorageTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Storage.Delete(Contact);
        }

        [Test]
        public void Should_remove_file()
        {
            File.Exists($@"C:\TestStorage\Contacts\{Contact.Id}").Should().Be(false);
        }
    }

    [TestFixture]
    public class When_getting_all_contacts : StorageTestBase
    {
        [Test]
        public void Should_return_contacts()
        {
            var contacts = Storage.All();
            contacts.First().Name.Should().Be(Contact.Name);
        }
    }
}