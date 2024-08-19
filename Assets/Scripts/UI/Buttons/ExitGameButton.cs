using UnityEngine;

namespace UI
{
    public class ExitGameButton : BaseButton
    {
        public override void OnClick()
        {
            Application.Quit();
        }
    }
}