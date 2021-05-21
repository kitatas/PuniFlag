using Kai.Common.Application;
using Kai.Common.Presentation.View;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    public sealed class NextButtonView : MonoBehaviour
    {
        [SerializeField] private ButtonActivator buttonActivator = default;
        [SerializeField] private ButtonFader buttonFader = default;

        public void Init()
        {
            buttonFader.Init();
        }

        public void Activate(bool value)
        {
            buttonActivator.Activate(value);
        }

        public void FadeIn()
        {
            buttonFader.FadeIn();
        }

        public void FadeOut()
        {
            buttonFader.FadeOut(CommonViewConfig.UI_ANIMATION_TIME);
        }
    }
}