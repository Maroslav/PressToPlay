using Assets.Code.Model;
using Assets.Code.Model.Attribs;
using NUnit.Framework;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class AttributesLoading
    {
        [Test]
        public void AttributesStructureTest()
        {
            AttributesDefinition atts = XmlUtils.LoadAttributes("Attributes/attributes_test");
            Assert.AreEqual(4,atts.Categories.Length,"Categories count does not match");
            var cat = atts.Categories[0];
            Assert.AreEqual("Cat A",cat.Name, "Name of the category does not match");
            Assert.AreEqual(1, cat.Attributes.Length, "Count of the elements in the category does not match.");
            var attrib = cat.Attributes[0];
            Assert.AreEqual("Att1", attrib.Name, "Name of the attribute does not match.");
            Assert.AreEqual("Descr1", attrib.Description, "Description of the attribute does not match.");
            Assert.AreEqual(500, attrib.InitialValue, "Initial value of the attribute does not match.");
            Assert.AreEqual(true, attrib.IsDisplayed, "IsDisplayed value of the attribute does not match.");

            cat = atts.Categories[1];
            Assert.AreEqual("Cat B", cat.Name, "Name of the category does not match");
            Assert.AreEqual(1, cat.Attributes.Length, "Count of the elements in the category does not match.");
            attrib = cat.Attributes[0];
            Assert.AreEqual("Att2", attrib.Name, "Name of the attribute does not match.");
            Assert.AreEqual("Descr2", attrib.Description, "Description of the attribute does not match.");
            Assert.AreEqual(500, attrib.InitialValue, "Initial value of the attribute does not match.");
            Assert.AreEqual(false, attrib.IsDisplayed, "IsDisplayed value of the attribute does not match.");

            cat = atts.Categories[2];
            Assert.AreEqual("Cat C", cat.Name, "Name of the category does not match");
            Assert.AreEqual(0, cat.Attributes.Length, "Count of the elements in the category does not match.");

            cat = atts.Categories[3];
            Assert.AreEqual("Cat D", cat.Name, "Name of the category does not match");
            Assert.AreEqual(2, cat.Attributes.Length, "Count of the elements in the category does not match.");
            attrib = cat.Attributes[0];
            Assert.AreEqual("Att3", attrib.Name, "Name of the attribute does not match.");
            Assert.AreEqual("Descr3", attrib.Description, "Description of the attribute does not match.");
            Assert.AreEqual(0, attrib.InitialValue, "Initial value of the attribute does not match.");
            Assert.AreEqual(false, attrib.IsDisplayed, "IsDisplayed value of the attribute does not match.");

            attrib = cat.Attributes[1];
            Assert.AreEqual("Att4", attrib.Name, "Name of the attribute does not match.");
            Assert.AreEqual("Descr4", attrib.Description, "Description of the attribute does not match.");
            Assert.AreEqual(1000, attrib.InitialValue, "Initial value of the attribute does not match.");
            Assert.AreEqual(false, attrib.IsDisplayed, "IsDisplayed value of the attribute does not match.");
        }
    }
}
