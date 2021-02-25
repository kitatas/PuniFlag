using System;
using Common.View.Button;
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

        private int _level;
        private SceneLoader _sceneLoader;
        private ButtonActivator _buttonActivator;
        private ButtonAnimator _buttonAnimator;

        [Inject]
        private void Construct(int level, SceneLoader sceneLoader)
        {
            _level = level;
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
            LoadScene();
            _buttonAnimator.Play();
        }

        private void LoadScene()
        {
            switch (loadType)
            {
                case LoadType.Direct:
                    _sceneLoader.LoadScene(sceneName);
                    break;
                case LoadType.Next:
                    var nextLevel = _level + 1;
                    var loadLevel = nextLevel < Const.STAGE_COUNT ? nextLevel : 0;
                    _sceneLoader.LoadScene(sceneName, loadLevel);
                    break;
                case LoadType.Reload:
                    _sceneLoader.LoadScene(sceneName, _level);
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