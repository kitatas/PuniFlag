using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Kai.Common.Presentation.Controller
{
    public sealed class RenderCameraSetter : MonoBehaviour
    {
        [SerializeField] private Canvas canvas = default;

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => canvas.worldCamera == null)
                .Subscribe(_ =>
                {
                    canvas.worldCamera = FindFirstObjectByType<Camera>();
                    canvas.sortingLayerName = "UI";
                    canvas.sortingOrder = 999;
                })
                .AddTo(this);
        }
    }
}