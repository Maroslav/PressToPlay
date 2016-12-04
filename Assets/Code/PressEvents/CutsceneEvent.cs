﻿using System;
using UnityEngine.Assertions;

namespace Assets.Code.PressEvents
{
    public class CutsceneEvent : PressEvent
    {
        public string ImagePath { get; private set; }
        public string Description { get; private set; }


        public CutsceneEvent(string imagePath, string description, DateTime date)
            : base(date)
        {
            Assert.IsNotNull(imagePath);
            Assert.IsFalse(imagePath.StartsWith("/"), "The image path cannot start with a slash.");
            ImagePath = imagePath;

            Assert.IsNotNull(description);
            Description = description;
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