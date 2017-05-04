using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.Storage.Tests
{
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
}