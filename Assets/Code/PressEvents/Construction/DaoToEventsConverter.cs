using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Model;
using Assets.Code.Model.Events;
using Assets.Code.Model.Events.Choices;
using Assets.Code.Model.Events.Effects;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents.Construction
{
    /// <summary>
    /// Converts data access objects loaded from database to events.
    /// </summary>
    class DaoToEventsConverter : IPressEventDaoProcessor<PressEvent>
    {
        /// <summary>
        /// The date that is assigned to events if the event has no date itself.
        /// </summary>
        public DateTime AssignedDate { get; set; }
        private readonly DaoToEffectsConverter _effectsConverter = new DaoToEffectsConverter();
        public PressEvent Process(MultipleChoiceEventDao evt)
        {
            var d = GetDate(evt);
            List<TextChoice> choices = new List<TextChoice>(evt.Choices.Length);
            foreach (var choiceDao in evt.Choices)
            {
                var effects = GetEffects(choiceDao);
                choices.Add(new TextChoice(effects,choiceDao.ChoiceText,choiceDao.Title,choiceDao.Description,choiceDao.ArticleText,choiceDao.ImagePath,choiceDao.ImageLabel));
            }
            var descr = evt.Description;
            var precond = GetPreconditions(evt);
            return new MultipleChoiceEvent(descr,d,choices,evt.IsTerminating,precond);
        }


        public PressEvent Process(ImageChoiceEventDao evt)
        {
            var d = GetDate(evt);
            List<ImageChoice> choices = new List<ImageChoice>(evt.Choices.Length);
            foreach (var choiceDao in evt.Choices)
            {
                var effects = GetEffects(choiceDao);
                choices.Add(new ImageChoice(effects, choiceDao.ImagePath,choiceDao.ImageLabel,choiceDao.Title,choiceDao.Description,choiceDao.ArticleText));
            }
            var description = evt.Description;
            var preconditions = GetPreconditions(evt);
            var terminating = evt.IsTerminating;
            return new ImageChoiceEvent(d,terminating,preconditions,choices,description);
        }

        public PressEvent Process(CutsceneEventDao evt)
        {
            var d = GetDate(evt);
            var preconditions = GetPreconditions(evt);
            return new CutsceneEvent(evt.ImagePath, evt.Text,d, evt.IsTerminating,preconditions);
        }
        private DateTime GetDate(PressEventDao evt)
        {
            DateTime d;
            if (!string.IsNullOrEmpty(evt.Date))
            {
                if (DateTime.TryParse(evt.Date, out d))
                {
                    return d;
                }
            }
            d = AssignedDate;
            return d;
        }

        private List<Precondition> GetPreconditions(PressEventDao dao)
        {
            if (dao.Preconditions==null) return new List<Precondition>();
            return (from x in dao.Preconditions select Precondition.FromDao(x)).ToList();

        }
        private List<Effect> GetEffects(ChoiceDao choiceDao)
        {
            if (choiceDao.Effects==null) return new List<Effect>();
            return (from x in choiceDao.Effects select x.Process(_effectsConverter)).ToList();
        }

    }
}
