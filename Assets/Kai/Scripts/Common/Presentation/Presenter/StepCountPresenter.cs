using Common.Domain.Model.Interface;
using Common.Presentation.View;
using UniRx;

namespace Common.Presentation.Presenter
{
    public sealed class StepCountPresenter
    {
        public StepCountPresenter(IStepCountModel stepCountModel, StepCountView stepCountView)
        {
            stepCountModel.stepCount
                .Subscribe(stepCountView.Display)
                .AddTo(stepCountView);
        }
    }
}