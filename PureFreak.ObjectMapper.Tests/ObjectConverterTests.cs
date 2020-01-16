using Microsoft.VisualStudio.TestTools.UnitTesting;
using PureFreak.ObjectMapper.Tests.Entities;
using System;

namespace PureFreak.ObjectMapper.Tests
{
    [TestClass]
    public class ObjectConverterTests
    {
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
        public void ConvertShouldCopyObject()
        {
            var source = CreateSourceEntity();

            IObjectConverter converter = new ObjectConverter();
            var target = converter.Convert<TargetEntity>(source);

            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Username, target.Username);
        }

        [TestMethod]
        public void ConvertShouldReturnNullIfSourceIsNull()
        {
            IObjectConverter converter = new ObjectConverter();
            var target = converter.Convert<TargetEntity>(null);

            Assert.IsNull(target);
        }

        [TestMethod]
        public void MapPropertiesShouldCopyProperties()
        {
            var source = CreateSourceEntity();
            var target = new TargetEntity();

            IObjectConverter converter = new ObjectConverter();
            converter.MapProperties(source, target);

            Assert.AreEqual(source.Id, target.Id);
            Assert.AreEqual(source.Username, target.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapPropertiesShouldThrowExceptionIfSourceIsNull()
        {
            IObjectConverter converter = new ObjectConverter();
            converter.MapProperties<SourceEntity, TargetEntity>(null, new TargetEntity());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapPropertiesShouldThrowExceptionIfTargetIsNull()
        {
            IObjectConverter converter = new ObjectConverter();
            converter.MapProperties<SourceEntity, TargetEntity>(new SourceEntity(), null);
        }
    }
}
