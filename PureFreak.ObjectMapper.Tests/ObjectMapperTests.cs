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
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private SourceEntity CreateSourceEntity()
        {
            return new SourceEntity
            {
                Id = 10,
                Firstname = "Max",
                Lastname = "Mustermann",
                Username = "MaxMustermann"
            };
        }

        [TestMethod]
        public void ShouldCopyObject()
        {
            var source = CreateSourceEntity();

            IObjectConverter converter = new ObjectConverter();
            var target = converter.Convert<TargetEntity>(source);

            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Username, target.Username);
        }

        [TestMethod]
        public void ShouldCopyProperties()
        {
            var source = CreateSourceEntity();
            var target = new TargetEntity();

            IObjectConverter converter = new ObjectConverter();
            converter.MapProperties(source, target);

            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Username, target.Username);
        }

        [TestMethod]
        public void ShouldReturnNullIfSourceIsNull()
        {
            IObjectConverter converter = new ObjectConverter();
            var target = converter.Convert<TargetEntity>(null);

            Assert.IsNull(target);
        }
    }
}
