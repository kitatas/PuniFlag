using System;
using Common.View.Button;
using Game.Stage.Level;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Common.Transition
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ButtonActivator))]
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class LoadButton : MonoBehaviour
    {
        [SerializeField] private SceneName sceneName = default;
        [SerializeField] private LoadType loadType = default;
        [SerializeField] private bool isLoad = true;

        private readonly Subject<Unit> _subject = new Subject<Unit>();
        public IObservable<Unit> onPush => _subject;

        private LevelModel _levelModel;
        private SceneLoader _sceneLoader;
        private ButtonActivator _buttonActivator;
        private ButtonAnimator _buttonAnimator;

        [Inject]
        private void Construct(LevelModel levelModel, SceneLoader sceneLoader)
        {
            _levelModel = levelModel;
            _sceneLoader = sceneLoader;
            _buttonActivator = GetComponent<ButtonActivator>();
            _buttonAnimator = GetComponent<ButtonAnimator>();
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _subject.OnNext(Unit.Default);
                    if (isLoad)
                    {
                        Push();
                    }
                })
                .AddTo(this);
        }

        public void Push()
        {
            LoadScene(loadType);
            _buttonAnimator.Play();
        }

        public void LoadScene(LoadType type)
        {
            switch (type)
            {
                case LoadType.Direct:
                    _sceneLoader.LoadScene(sceneName);
                    break;
                case LoadType.Next:
                    _levelModel.LevelUp();
                    _sceneLoader.LoadScene(sceneName, _levelModel.GetLevel());
                    break;
                case LoadType.Reload:
                    _sceneLoader.LoadScene(sceneName, _levelModel.GetLevel());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Activate(bool value)
        {
            _buttonActivator.Activate(value);
        }
    }
}