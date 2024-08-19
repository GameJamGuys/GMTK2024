namespace UI
{
    public class RetryButton : BaseButton
    {
        public override void OnClick()
        {
            Loader.Load(Loader.Scene.Gameplay);
        }
    }
}