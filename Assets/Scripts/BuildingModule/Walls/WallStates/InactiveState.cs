namespace BuildingModule
{
    public class InactiveState : WallStateBase
    {
        public override void Initiate()
        {
            ThisWall.Renderer.enabled = false;
        }
    }
}