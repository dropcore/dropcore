using DropCore.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DropCore.IO.Tests
{
    [TestClass]
    public class JsonFileReaderTest : UnitTest
    {
        [TestMethod]
        public void JsonFileReader_Can_Read_Valid_Json_File()
        {
            using (var reader = new JsonFileReader(@"FixtureFiles\test.json"))
            {
                var json = reader.Read();

                Assert.AreEqual("world", json["hello"].ToObject<string>());
            }
        }

        [TestMethod]
        public void JsonFileReader_Raises_FileNotFoundException_If_Supplied_Path_Does_Not_Exists()
        {
            AssertRaise<FileNotFoundException>(() =>
            {
                using (var reader = new JsonFileReader("does_not_exist.json"))
                {
                    var json = reader.Read();
                }
            });
        }
    }
}
