using System;
using UnityEngine;

namespace TopDownGame
{
    [Serializable]
    public class IntParam : AnimatorParam<int>
    {
        public IntParam(string name, Animator animator) : base(name, animator)
        {
        }

        protected override void OnValueChanged(int value)
        {
            _animator.SetInteger(_hash, value);
        }

        protected override AnimatorControllerParameterType ParamType => AnimatorControllerParameterType.Int;
    }
}
