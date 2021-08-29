using Kai.Common.Application;
using Kai.Common.Extension;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class ScrollRectResetView : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect = default;

        private void Start()
        {
            GetComponent<ButtonActivator>().button
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    this.DelayAction(CommonViewConfig.POPUP_ANIMATION_TIME, () =>
                    {
                        scrollRect.verticalNormalizedPosition = 1.0f;
                    });
                })
                .AddTo(this);
        }
    }
}