using Kai.Common.Domain.Model.Interface;
using Kai.Common.Presentation.View;
using UniRx;

namespace Kai.Common.Presentation.Presenter
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