using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ThinkAboutLessonAction : ThinkingActionBase
    {
        public ThinkAboutLessonAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public ThinkAboutLessonAction() : base()
        {

        }
    }
}