using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.ObjectMapper.Tests
{
    [TestClass]
    public class ObjectMapperTests
    {
        class SourceEntity
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }

        class TargetEntity
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [TestMethod]
        public void ShouldCopyObject()
        {
            var source = new SourceEntity
            {
                Id = 10,
                Firstname = "Max",
                Lastname = "Mustermann",
                Username = "MaxMustermann"
            };

            IObjectConverter converter = new ObjectConverter();
            var target = converter.Convert<TargetEntity>(source);

            Assert.AreEqual(source.Username, target.Username);
        }
    }
}
