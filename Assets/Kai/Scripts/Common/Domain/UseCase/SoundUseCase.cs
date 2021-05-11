using System;
using Common.Application;
using Common.Domain.Repository.Interface;
using Common.Domain.UseCase.Interface;
using UnityEngine;

namespace Common.Domain.UseCase
{
    public sealed class SoundUseCase : IBgmUseCase, ISeUseCase
    {
        private readonly ISoundRepository _soundRepository;

        public SoundUseCase(ISoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public AudioClip GetBgmClip(BgmType bgmType) => _soundRepository.FindBgm(bgmType);

        public AudioClip GetSeClip(SeType seType) => _soundRepository.FindSe(seType);

        public AudioClip GetSeClip(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.Decision:
                    return GetSeClip(SeType.Decision);
                case ButtonType.Cancel:
                    return GetSeClip(SeType.Cancel);
                default:
                    throw new ArgumentOutOfRangeException(nameof(buttonType), buttonType, null);
            }
        }
    }
}