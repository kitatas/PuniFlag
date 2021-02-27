using UniRx;

namespace Game.StepCount
{
    public sealed class StepCountPresenter
    {
        public StepCountPresenter(StepCountModel stepCountModel, StepCountView stepCountView)
        {
            stepCountModel.stepCount
                .Subscribe(stepCountView.Display)
                .AddTo(stepCountView);
        }
    }
}