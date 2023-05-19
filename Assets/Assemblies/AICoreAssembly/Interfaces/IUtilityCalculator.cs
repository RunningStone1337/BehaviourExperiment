namespace BehaviourModel
{
    public interface IUtilityCalculator 
    {
        float CalculateUtility(IUtilityCalculationSource source);
    }
}
