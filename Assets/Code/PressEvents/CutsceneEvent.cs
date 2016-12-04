using System;
using UnityEngine.Assertions;

namespace Assets.Code.PressEvents
{
    public class CutsceneEvent : PressEvent
    {
        public string ImagePath { get; private set; }


        public CutsceneEvent(string imagePath, DateTime date)
            : base(date)
        {
            Assert.IsNotNull(imagePath);
            Assert.IsFalse(imagePath.StartsWith("/"), "The image path cannot start with a slash.");
            ImagePath = imagePath;
        }


        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }


        public void Finish()
        {
            IsFinished = true;
        }
    }
}
