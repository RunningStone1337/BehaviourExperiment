using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public enum Emotions
    {
        Annoyance,
        Anger,
        Rage,
        Approval,
        Acceptance,
        Adoration,
        Abstractness,
        Surprise,
        Amazement,
        Disapproval,
        Dislike,
        Disgust,
        Caution,
        Fear,
        Horror,
        Serenity,
        Happy,
        Eiphoria,
        Interest,
        Awaiting,
        Anticipation,
        Despondency,
        Sad,
        Misery
    }
    [CreateAssetMenu(menuName = "RelationshipTables/CharacterEmotionsEnumTable", fileName = "NewMatrix")]
    public class CharacterEmotions : CharacterListTableBase<Emotions>
    {
       
    }
}