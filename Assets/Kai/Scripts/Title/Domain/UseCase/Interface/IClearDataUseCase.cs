namespace Kai.Title.Domain.UseCase.Interface
{
    public interface IClearDataUseCase
    {
        bool[] rankData { get; }
        bool[] clearData { get; }
    }
}