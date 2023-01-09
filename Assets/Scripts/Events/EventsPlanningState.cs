using UI;

namespace Common
{
    public class EventsPlanningState : SceneStateBase
    {
        public override void Initiate()
        {
            CanvasController.Controller.CurrentState = CanvasController.Controller.EventsPlanningScreen;
        }
    }
}