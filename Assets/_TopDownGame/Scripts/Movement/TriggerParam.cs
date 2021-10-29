using System;
using UnityEngine;

namespace TopDownGame
{
    [Serializable]
    public class TriggerParam : AnimatorParameter
    {
        public TriggerParam(string name, Animator animator) : base(name, animator)
        {
        }

        protected override AnimatorControllerParameterType ParamType => AnimatorControllerParameterType.Trigger;

        public void Trigger()
        {
            _animator.SetTrigger(_hash);
        }
    }
}
