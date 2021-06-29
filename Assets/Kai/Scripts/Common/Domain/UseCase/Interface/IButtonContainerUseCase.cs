namespace Kai.Common.Domain.UseCase.Interface
{
    public interface IButtonContainerUseCase
    {
        void ActivateButton(bool value);
        void ClearAllButton();
    }
}