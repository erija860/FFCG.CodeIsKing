using NUnit.Framework;

namespace FFCG.G5.Storage.Tests
{
    [TestFixture]
    public class When_creating_a_file_storage : StorageTestBase
    {
        [Test]
        public void Should_create_correct_folder_path()
        {
            DirectoryAssert.Exists(@"C:\TestStorage\Contacts");
        }
    }
}