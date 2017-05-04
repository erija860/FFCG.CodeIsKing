using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.Storage.Tests
{
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