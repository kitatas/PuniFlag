using UniRx;

namespace Game.StepCount
{
    public sealed class StepCountPresenter
    {
        private readonly StepCountModel _stepCountModel;
        private readonly StepCountView _stepCountView;

        public StepCountPresenter(StepCountModel stepCountModel, StepCountView stepCountView)
        {
            _stepCountModel = stepCountModel;
            _stepCountView = stepCountView;

            _stepCountModel.stepCount
                .Subscribe(_stepCountView.Display)
                .AddTo(_stepCountView);
        }

        public void ResetCount() => _stepCountModel.ResetStepCount();

        public void TweenBottom() => _stepCountView.TweenBottom();

        public void TweenCenter() => _stepCountView.TweenCenter();
    }
}