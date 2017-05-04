using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.Storage.Tests
{
    [TestFixture]
    public class When_storing_a_contact : StorageTestBase
    {
        [Test]
        public void Should_create_file()
        {
            File.Exists($@"C:\TestStorage\Contacts\{Contact.Id}").Should().Be(true);
        }
    }
}