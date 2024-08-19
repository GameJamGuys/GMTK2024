namespace UI
{
    public class GoToMainMenuButton : BaseButton
    {
        public override void OnClick()
        {
            Loader.Load(Loader.Scene.MainMenu);
        }
    }
}