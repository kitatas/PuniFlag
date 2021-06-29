using System.Collections.Generic;
using Kai.Common.Data.Container.Interface;
using Kai.Common.Presentation.View;
using UnityEngine;

namespace Kai.Common.Data.Container
{
    public sealed class ButtonContainer : IReadOnlyButtonContainer
    {
        private ButtonActivator[] _buttonActivators;

        private IEnumerable<ButtonActivator> buttonActivators
        {
            get
            {
                if (_buttonActivators == null)
                {
                    _buttonActivators = Object.FindObjectsOfType<ButtonActivator>();
                }

                return _buttonActivators;
            }
        }

        public void ActivateAll(bool value)
        {
            foreach (var buttonActivator in buttonActivators)
            {
                buttonActivator.Activate(value);
            }
        }

        public void ClearAll()
        {
            _buttonActivators = null;
        }
    }
}