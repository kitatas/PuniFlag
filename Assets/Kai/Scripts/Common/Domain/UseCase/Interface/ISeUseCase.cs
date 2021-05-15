using Kai.Common.Application;
using UnityEngine;

namespace Kai.Common.Domain.UseCase.Interface
{
    public interface ISeUseCase
    {
        AudioClip GetSeClip(SeType seType);
        AudioClip GetSeClip(ButtonType buttonType);
    }
}