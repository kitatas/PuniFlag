using System;
using Common.Sound.SE;
using Common.View.Button;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Player
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ButtonActivator))]
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class MoveButton : MonoBehaviour
    {
        [SerializeField] private MoveDirection moveDirection = default;
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
            _seController.PlaySe(SeType.Decision);
            // (moveDirection);
            _buttonAnimator.Play();
        }

        public void Activate(bool value)
        {
            _buttonActivator.Activate(value);
        }
    }
}