using System;
using Common.Application;
using Common.Presentation.Controller;
using Common.View.Button;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    [RequireComponent(typeof(ButtonActivator))]
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class GameButton : MonoBehaviour
    {
        [SerializeField] private ButtonType buttonType = default;

        private readonly Subject<Unit> _subject = new Subject<Unit>();
        public IObservable<Unit> onPush => _subject;

        private SeController _seController;
        private ButtonActivator _buttonActivator;
        private ButtonAnimator _buttonAnimator;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
            _buttonActivator = GetComponent<ButtonActivator>();
            _buttonAnimator = GetComponent<ButtonAnimator>();
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => _subject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void Push()
        {
            _seController.PlaySe(buttonType);
            _buttonAnimator.Play();
        }

        public void Activate(bool value)
        {
            _buttonActivator.Activate(value);
        }
    }
}