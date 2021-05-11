using Common.Application;
using UnityEngine;

namespace Common.Domain.UseCase.Interface
{
    public interface ISeUseCase
    {
        AudioClip GetSeClip(SeType seType);
        AudioClip GetSeClip(ButtonType buttonType);
    }
}