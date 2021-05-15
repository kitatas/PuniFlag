using System;
using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using Kai.Game.Application;
using Kai.Game.Domain.UseCase.Interface;
using Kai.Game.Presentation.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kai.Game.Presentation.Controller
{
    public sealed class ButtonController : MonoBehaviour
    {
        [SerializeField] private GameButtonView moveLeft = default;
        [SerializeField] private GameButtonView moveRight = default;
        [SerializeField] private GameButtonView rotateLeft = default;
        [SerializeField] private GameButtonView rotateRight = default;
        [SerializeField] private GameButtonView loadTitle = default;
        [SerializeField] private GameButtonView resetStage = default;

        private readonly Subject<InputType> _subject = new Subject<InputType>();
        public IObservable<InputType> PushButton() => _subject;

        private IInputUseCase _inputUseCase;
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(IInputUseCase inputUseCase, SceneLoader sceneLoader)
        {
            _inputUseCase = inputUseCase;
            _sceneLoader = sceneLoader;
        }

        public void InitInput()
        {
            var tickObservable = this.UpdateAsObservable();

            tickObservable
                .Where(_ => _inputUseCase.isMoveLeft)
                .Merge(moveLeft.OnPush())
                .Subscribe(_ =>
                {
                    // 
                    _subject.OnNext(InputType.MoveLeft);
                    moveLeft.Push();
                })
                .AddTo(this);

            tickObservable
                .Where(_ => _inputUseCase.isMoveRight)
                .Merge(moveRight.OnPush())
                .Subscribe(_ =>
                {
                    //
                    _subject.OnNext(InputType.MoveRight);
                    moveRight.Push();
                })
                .AddTo(this);

            tickObservable
                .Where(_ => _inputUseCase.isRotateLeft)
                .Merge(rotateLeft.OnPush())
                .Subscribe(_ =>
                {
                    //
                    _subject.OnNext(InputType.RotateLeft);
                    rotateLeft.Push();
                })
                .AddTo(this);

            tickObservable
                .Where(_ => _inputUseCase.isRotateRight)
                .Merge(rotateRight.OnPush())
                .Subscribe(_ =>
                {
                    // 
                    _subject.OnNext(InputType.RotateRight);
                    rotateRight.Push();
                })
                .AddTo(this);

            tickObservable
                .Where(_ => _inputUseCase.isBack)
                .Merge(loadTitle.OnPush())
                .Subscribe(_ =>
                {
                    loadTitle.Push();
                    _sceneLoader.LoadScene(SceneName.Title);
                })
                .AddTo(this);

            tickObservable
                .Where(_ => _inputUseCase.isReset)
                .Merge(resetStage.OnPush())
                .Subscribe(_ =>
                {
                    resetStage.Push();
                    _sceneLoader.LoadScene(SceneName.Main, LoadType.Reload);
                })
                .AddTo(this);
        }
    }
}