namespace BehaviourModel
{
    public interface IAgent
    {
        void StartActing();
        void StopActing();
        void BreakCurrentActing();
    }
}