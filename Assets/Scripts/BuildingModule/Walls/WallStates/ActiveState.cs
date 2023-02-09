namespace BuildingModule
{
    public class ActiveState : WallStateBase
    {
        public override void Initiate()
        {
            ThisWall.Renderer.enabled = true;
            ThisWall.WallCollider.enabled = true;
        }
    }
}