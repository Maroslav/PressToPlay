using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.Model.Events.Effects;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using NUnit.Framework;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class AlgorithmTests
    {
        private List<Effect> EffectsWithMoveTowardsCredibility(int credibilityValue)
        {
            return new List<Effect> () {new MoveTowardsEffect(Attribs.Credibility, credibilityValue,100)};
        }

        private WorldState WorldStateWithCredibility(int value)
        {
            WorldState state=new WorldState();
            state.JournalistState = new Attribs();
            state.JournalistState[Attribs.Credibility] = value;
            return state;
        }
        [Test]
        public void ClosestChoicesTest()
        {
           List<TextChoice>  choices = new List<TextChoice>()
           {
               new TextChoice(EffectsWithMoveTowardsCredibility(500),"Choice 1","Choice 1","Long description of the choice 1"),
               new TextChoice(EffectsWithMoveTowardsCredibility(700),"Choice 2","Choice 2","Long description of the choice 2"),
               new TextChoice(EffectsWithMoveTowardsCredibility(200),"Choice 2","Choice 2","Long description of the choice 3"),
               new TextChoice(EffectsWithMoveTowardsCredibility(200),"Choice 4","Choice 4","Long description of the choice 4")
           };
            var journalist = WorldStateWithCredibility(650);
            var closest = Algorithms.Closest(choices, journalist, 2);
            Assert.IsTrue(closest.Count==2);
            Assert.IsTrue(closest[0].Title == "Choice 1");
            Assert.IsTrue(closest[1].Title == "Choice 2");
            Assert.IsTrue(closest[0].Effects[0].Value == 500);
            Assert.IsTrue(closest[1].Effects[0].Value == 700);
        }
        [Test]
        public void ClosestChoicesTest2()
        {
            List<TextChoice> choices = new List<TextChoice>()
           {
               new TextChoice(EffectsWithMoveTowardsCredibility(200),"Choice 3","Choice 3","Long description of the choice 1"),
               new TextChoice(EffectsWithMoveTowardsCredibility(201),"Choice 4","Choice 4","Long description of the choice 2"),
               new TextChoice(EffectsWithMoveTowardsCredibility(500),"Choice 1","Choice 1","Long description of the choice 3"),
               new TextChoice(EffectsWithMoveTowardsCredibility(700),"Choice 2","Choice 2","Long description of the choice 4")
           };
            var journalist = WorldStateWithCredibility(900);
            var closest = Algorithms.Closest(choices, journalist, 6);
            Assert.IsTrue(closest.Count == 4);
            Assert.AreEqual("Choice 3",closest[0].Title);
            Assert.AreEqual("Choice 4", closest[1].Title );
            Assert.AreEqual("Choice 1", closest[2].Title ); 
            Assert.AreEqual("Choice 2", closest[3].Title );
            Assert.AreEqual(closest[3].Effects[0].Value, 700);

        }
        [Test]
        public void ClosestChoicesTest3()
        {
            List<TextChoice> choices = new List<TextChoice>()
           {
               new TextChoice(EffectsWithMoveTowardsCredibility(200),"Choice 3","Choice 3","Long description of the choice 1"),
               new TextChoice(EffectsWithMoveTowardsCredibility(201),"Choice 4","Choice 4","Long description of the choice 2"),
               new TextChoice(EffectsWithMoveTowardsCredibility(500),"Choice 1","Choice 1","Long description of the choice 3"),
               new TextChoice(EffectsWithMoveTowardsCredibility(700),"Choice 2","Choice 2","Long description of the choice 4")
           };
            var journalist = WorldStateWithCredibility(900);
            var closest = Algorithms.Closest(choices, journalist, 1);
            Assert.IsTrue(closest.Count == 1);
            Assert.AreEqual("Choice 2", closest[0].Title);
            Assert.AreEqual(closest[0].Effects[0].Value, 700);

        }
        [Test]
        public void ClosestChoicesTest4()
        {
            List<TextChoice> choices = new List<TextChoice>()
           {
               new TextChoice(EffectsWithMoveTowardsCredibility(200),"Choice 3","Choice 3","Long description of the choice 1"),
               new TextChoice(EffectsWithMoveTowardsCredibility(201),"Choice 4","Choice 4","Long description of the choice 2"),
               new TextChoice(EffectsWithMoveTowardsCredibility(500),"Choice 1","Choice 1","Long description of the choice 3"),
               new TextChoice(EffectsWithMoveTowardsCredibility(700),"Choice 2","Choice 2","Long description of the choice 4")
           };
            var journalist = WorldStateWithCredibility(202);
            var closest = Algorithms.Closest(choices, journalist, 1);
            Assert.IsTrue(closest.Count == 1);
            Assert.AreEqual("Choice 4", closest[0].Title);
            Assert.AreEqual(closest[0].Effects[0].Value, 201);
        }

    }
}
