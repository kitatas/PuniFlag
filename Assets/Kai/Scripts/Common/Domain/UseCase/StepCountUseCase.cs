using Kai.Common.Data.Entity.Interface;
using Kai.Common.Domain.Model.Interface;
using Kai.Common.Domain.UseCase.Interface;

namespace Kai.Common.Domain.UseCase
{
    public sealed class StepCountUseCase : IStepCountUseCase
    {
        private readonly IStepCountEntity _stepCountEntity;
        private readonly IStepCountModel _stepCountModel;

        public StepCountUseCase(IStepCountEntity stepCountEntity, IStepCountModel stepCountModel)
        {
            _stepCountEntity = stepCountEntity;
            _stepCountModel = stepCountModel;
        }

        public int GetStepCount() => _stepCountEntity.GetStepCount();

        public void CountUp()
        {
            _stepCountEntity.CountUp();
            _stepCountModel.SetStepCount(GetStepCount());
        }

        public void ResetStepCount()
        {
            _stepCountEntity.ResetStepCount();
            _stepCountModel.SetStepCount(GetStepCount());
        }
    }
}