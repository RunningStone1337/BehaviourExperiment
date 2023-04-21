using Common;
using UnityEngine;

namespace BehaviourModel
{
    public enum ActionType
    {
        Default,
        AskGoToBoard,
        Agree,
        Decline,
        Dream,
        WriteLesson,
        PayAttention,
        ExplainLesson
    }
    public class ActionsImagesDictionary : DictionaryBase<ActionType, Sprite>
    {
        public static ActionsImagesDictionary Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(this);
        }
    }
}
