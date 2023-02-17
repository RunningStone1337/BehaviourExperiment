namespace BehaviourModel
{
    public interface IAttentionCalculator<TPhenom> where TPhenom : IPhenomenon
    {
        float CalculateAttentionForPhenomenon(TPhenom phenom);
    }
}