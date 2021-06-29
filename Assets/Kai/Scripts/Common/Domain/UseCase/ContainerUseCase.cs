using Kai.Common.Data.Container.Interface;
using Kai.Common.Domain.UseCase.Interface;

namespace Kai.Common.Domain.UseCase
{
    public sealed class ContainerUseCase : IButtonContainerUseCase
    {
        private readonly IReadOnlyButtonContainer _buttonContainer;

        public ContainerUseCase(IReadOnlyButtonContainer buttonContainer)
        {
            _buttonContainer = buttonContainer;
        }

        public void ActivateButton(bool value)
        {
            _buttonContainer.ActivateAll(value);
        }

        public void ClearAllButton()
        {
            _buttonContainer.ClearAll();
        }
    }
}