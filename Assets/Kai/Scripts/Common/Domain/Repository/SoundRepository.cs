using Common.Application;
using Common.Data.DataStore;
using Common.Domain.Repository.Interface;
using UnityEngine;

namespace Common.Domain.Repository
{
    public sealed class SoundRepository : ISoundRepository
    {
        private readonly BgmTable _bgmTable;
        private readonly SeTable _seTable;

        public SoundRepository(BgmTable bgmTable, SeTable seTable)
        {
            _bgmTable = bgmTable;
            _seTable = seTable;
        }

        public AudioClip FindBgm(BgmType bgmType)
        {
            return _bgmTable.bgmData
                .Find(x => x.bgmType == bgmType)
                .audioClip;
        }

        public AudioClip FindSe(SeType seType)
        {
            return _seTable.seData
                .Find(x => x.seType == seType)
                .audioClip;
        }
    }
}