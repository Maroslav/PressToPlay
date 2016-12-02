using System.Collections.Generic;
using Assets.Code.GameState;
using NUnit.Framework;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class AlgorithmTests
    {
        [Test]
        public void ZeroDistanceTest()
        {
            Attribs att1 = new Attribs();

            att1.AddAttribute(Attribs.Credibility, 500);
            
            Assert.IsTrue(Algorithms.Distance(att1,att1,Attribs.Credibility)==0);
        }
        [Test]
        public void NoAttributesDistanceTest()
        {
            Attribs att1 = new Attribs();
            att1.AddAttribute(Attribs.Credibility, 500);
            Assert.IsTrue(Algorithms.Distance(att1, att1) == 0);
        }
        [Test]
        public void AttributesDistanceTest1()
        {
            Attribs att1 = new Attribs();
            att1.AddAttribute(Attribs.Credibility, 500);
            Attribs att2 = new Attribs();
            att2.AddAttribute(Attribs.Credibility,800);
            att2.AddAttribute(new Attrib("Description"), 302);
            att2.AddAttribute(new Attrib("Some other attrib"), 801);
            Assert.IsTrue(Algorithms.Distance(att1, att2,Attribs.Credibility) == 300);
        }
        [Test]
        public void AttributesDistanceTest2()
        {
            Attribs att1 = new Attribs();
            att1.AddAttribute(Attribs.Credibility, 500);
            Attribs att2 = new Attribs();
            att2.AddAttribute(Attribs.Credibility, 800);
            att2.AddAttribute(new Attrib("Description"), 302);
            att2.AddAttribute(new Attrib("Some other attrib"), 801);
            Assert.IsTrue(Algorithms.Distance(att1, att2, Attribs.Credibility, new Attrib("AttributeListsDoNotContain")) == 300);
        }

        [Test]
        public void ClosestChoicesTest()
        {
               
        }
    }
}
