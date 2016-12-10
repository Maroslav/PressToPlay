using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.PressEvents;
using NUnit.Framework;
using Assets.Code.Test;
namespace Assets.Editor.Tests
{
    [TestFixture]
    class AlgorithmTests
    {
        [Test]
        public void ZeroDistanceTest()
        {
            Attribs att1 = new Attribs();

            att1[Attribs.Credibility] = 500;
            
            Assert.IsTrue(Algorithms.Distance(att1,att1,Attribs.Credibility)==0);
        }
        [Test]
        public void NoAttributesDistanceTest()
        {
            Attribs att1 = new Attribs();
            att1[Attribs.Credibility] = 500;
            Assert.IsTrue(Algorithms.Distance(att1, att1) == 0);
        }
        [Test]
        public void AttributesDistanceTest1()
        {
            Attribs att1 = new Attribs();
            att1[Attribs.Credibility] = 500;
            Attribs att2 = new Attribs();
            att2[Attribs.Credibility] = 800;
            att2[new Attrib("Description")] = 302;
            att2[new Attrib("Some other attrib")] = 801;
            Assert.IsTrue(Algorithms.Distance(att1, att2,Attribs.Credibility) == 300);
        }
        [Test]
        public void AttributesDistanceTest2()
        {
            Attribs att1 = new Attribs();
            att1[Attribs.Credibility] = 500;
            Attribs att2 = new Attribs();
            att2[Attribs.Credibility] = 800;
            att2[new Attrib("Description")] = 302;
            att2[new Attrib("Some other attrib")] = 801;
            Assert.IsTrue(Algorithms.Distance(att1, att2, Attribs.Credibility, new Attrib("AttributeListsDoNotContain")) == 300);
        }

        [Test]
        public void ClosestChoicesTest()
        {
           List<DecisionChoice>  choices = new List<DecisionChoice>()
           {
               new DecisionChoice(Attribs.AttributesWithCredibility(500),"Choice 1","Long description of the choice 1"),
               new DecisionChoice(Attribs.AttributesWithCredibility(700),"Choice 2","Long description of the choice 2"),
               new DecisionChoice(Attribs.AttributesWithCredibility(200),"Choice 2","Long description of the choice 3"),
               new DecisionChoice(Attribs.AttributesWithCredibility(200),"Choice 4","Long description of the choice 4")
           };
            Attribs journalist = Attribs.AttributesWithCredibility(650);
            var closest = Algorithms.Closest(choices, journalist, 2, new List<Attrib>() { Attribs.Credibility });
            Assert.IsTrue(closest.Count==2);
            Assert.IsTrue(closest[0].Title == "Choice 1");
            Assert.IsTrue(closest[1].Title == "Choice 2");
            Assert.IsTrue(closest[0].Attributes.Values[Attribs.Credibility] == 500);
            Assert.IsTrue(closest[1].Attributes.Values[Attribs.Credibility] == 700);
        }
        [Test]
        public void ClosestChoicesTest2()
        {
            List<DecisionChoice> choices = new List<DecisionChoice>()
           {
               new DecisionChoice(Attribs.AttributesWithCredibility(200),"Choice 3","Long description of the choice 1"),
               new DecisionChoice(Attribs.AttributesWithCredibility(201),"Choice 4","Long description of the choice 2"),
               new DecisionChoice(Attribs.AttributesWithCredibility(500),"Choice 1","Long description of the choice 3"),
               new DecisionChoice(Attribs.AttributesWithCredibility(700),"Choice 2","Long description of the choice 4")
           };
            Attribs journalist = Attribs.AttributesWithCredibility(900);
            var closest = Algorithms.Closest(choices, journalist, 6, new List<Attrib>() { Attribs.Credibility });
            Assert.IsTrue(closest.Count == 4);
            Assert.AreEqual("Choice 3",closest[0].Title);
            Assert.AreEqual("Choice 4", closest[1].Title );
            Assert.AreEqual("Choice 1", closest[2].Title ); 
            Assert.AreEqual("Choice 2", closest[3].Title );
            Assert.AreEqual(closest[3].Attributes.Values[Attribs.Credibility], 700);

        }
        [Test]
        public void ClosestChoicesTest3()
        {
            List<DecisionChoice> choices = new List<DecisionChoice>()
           {
               new DecisionChoice(Attribs.AttributesWithCredibility(200),"Choice 3","Long description of the choice 1"),
               new DecisionChoice(Attribs.AttributesWithCredibility(201),"Choice 4","Long description of the choice 2"),
               new DecisionChoice(Attribs.AttributesWithCredibility(500),"Choice 1","Long description of the choice 3"),
               new DecisionChoice(Attribs.AttributesWithCredibility(700),"Choice 2","Long description of the choice 4")
           };
            Attribs journalist = Attribs.AttributesWithCredibility(900);
            var closest = Algorithms.Closest(choices, journalist, 1, new List<Attrib>() { Attribs.Credibility });
            Assert.IsTrue(closest.Count == 1);
            Assert.AreEqual("Choice 2", closest[0].Title);
            Assert.AreEqual(closest[0].Attributes.Values[Attribs.Credibility], 700);

        }
        [Test]
        public void ClosestChoicesTest4()
        {
            List<DecisionChoice> choices = new List<DecisionChoice>()
           {
               new DecisionChoice(Attribs.AttributesWithCredibility(200),"Choice 3","Long description of the choice 1"),
               new DecisionChoice(Attribs.AttributesWithCredibility(201),"Choice 4","Long description of the choice 2"),
               new DecisionChoice(Attribs.AttributesWithCredibility(500),"Choice 1","Long description of the choice 3"),
               new DecisionChoice(Attribs.AttributesWithCredibility(700),"Choice 2","Long description of the choice 4")
           };
            Attribs journalist = Attribs.AttributesWithCredibility(202);
            var closest = Algorithms.Closest(choices, journalist, 1, new List<Attrib>() { Attribs.Credibility });
            Assert.IsTrue(closest.Count == 1);
            Assert.AreEqual("Choice 4", closest[0].Title);
            Assert.AreEqual(closest[0].Attributes.Values[Attribs.Credibility], 201);
        }

        [Test]
        public void MoveTowardsTest()
        {
            Attribs att1 = new Attribs();
            att1[Attribs.Credibility] = 500;
            var laziness = new Attrib("Laziness");
            var unused = new Attrib("Unused attribute");
            var partiallyUnused = new Attrib("Used only in one attributes list");
            att1[laziness] = 480;
            att1[partiallyUnused] = 900;
            Attribs att2 = new Attribs();
            att2[Attribs.Credibility] = 800;
            att2[laziness] = 500;
            List<Attrib> list = new List<Attrib>() {Attribs.Credibility,laziness,unused};
            Algorithms.MoveTowardsPosition(att1,att2,list);
            Assert.AreEqual(500+Algorithms.AttribMoveStep,att1[Attribs.Credibility]);
            Assert.AreEqual(att2[laziness],att1[laziness]);
            Assert.AreEqual(900,att1[partiallyUnused]);
        }

        [Test]
        public void MoveTowardsTest2()
        {
            Attribs att1 = new Attribs();
            att1[Attribs.Credibility] = 500;
            var laziness = new Attrib("Laziness");
            var unused = new Attrib("Unused attribute");
            var partiallyUnused = new Attrib("Used only in one attributes list");
            att1[laziness] = 480;
            att1[partiallyUnused] = 900;
            Attribs att2 = new Attribs();
            att2[Attribs.Credibility] = 100;
            att2[laziness] = 440;
            List<Attrib> list = new List<Attrib>() { Attribs.Credibility, laziness, unused };
            Algorithms.MoveTowardsPosition(att1, att2, list);
            Assert.AreEqual(500 - Algorithms.AttribMoveStep, att1[Attribs.Credibility]);
            Assert.AreEqual(att2[laziness], att1[laziness]);
            Assert.AreEqual(900, att1[partiallyUnused]);
        }
    }
}
