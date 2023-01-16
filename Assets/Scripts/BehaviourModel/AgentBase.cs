using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase : MonoBehaviour, IUIViewedObject
    {
        [SerializeField] private CharacterSystem characterSystem;
        [SerializeField] private NervousSystem nervousSystem;
        [SerializeField] private FeaturesSystem featuresSystem;
        [SerializeField] private SpriteRenderer agentRenderer;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] private string agentName;
        [SerializeField] private string agentDescription;
        [SerializeField] private SexBase agentSex;
        [SerializeField] ushort agentAge;
        [SerializeField] private ushort agentWeight;
        [SerializeField] private ushort agentHeight;

        public CharacterSystem CharacterSystem { get => characterSystem; protected set => characterSystem = value; }
        public NervousSystem NervousSystem { get => nervousSystem; protected set => nervousSystem = value; }
        public FeaturesSystem FeaturesSystem { get => featuresSystem; protected set => featuresSystem = value; }

        public string Name => agentName;

        public string ObjDescription => agentDescription;

        public Sprite PreviewSprite => previewSprite;

        public virtual void Initiate(HumanRawData data)
        {
            //TODO доделать инициализацию
            //previewSprite = 
            agentName = data.AgentName;
            agentSex = data.Sex;
            agentAge = data.age;
            agentWeight = data.Weight;
            agentHeight = data.Height;

            NervousSystem.Initiate(data);
            CharacterSystem.Initiate(data);
            FeaturesSystem.Initiate(data);
            transform.parent = null;
        }

    }
}