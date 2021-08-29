using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using UniRx;
using UnityEngine;
using Zenject;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class ButtonSpeaker : MonoBehaviour
    {
        [SerializeField] private bool isSubscribe = default;
        [SerializeField] private ButtonType buttonType = default;

        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
        }

        private void Start()
        {
            if (isSubscribe)
            {
                GetComponent<ButtonActivator>().button
                    .OnClickAsObservable()
                    .Subscribe(_ => Play())
                    .AddTo(this);
            }
        }

        public void Play()
        {
            _seController.PlaySe(buttonType);
        }
    }
}