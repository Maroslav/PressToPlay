using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Model.Events.Choices;

namespace Assets.Code.PressEvents.Choices
{
    public class ImageChoice:Choice
    {

        public ImageChoice(ImageChoiceDao source):base(source)
        {
            this.ImagePath = source.Path;
        }

        //Image path relative to the Resources folder
        public string ImagePath { get; set; }
    }
}
