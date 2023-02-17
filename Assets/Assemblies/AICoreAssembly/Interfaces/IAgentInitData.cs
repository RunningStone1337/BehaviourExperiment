namespace BehaviourModel
{
    public interface IAgentInitData<TFeature> :
        IRawCharacterInfoSource, IFeaturesHandler<TFeature>
        where TFeature : IFeature
    {
    }
}