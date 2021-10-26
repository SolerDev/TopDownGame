using System;
using UnityEngine;

namespace TopDownGame
{
    [Serializable]
    public class BoolParam : AnimatorParam<bool>
    {
        public BoolParam(string name, Animator animator) : base(name, animator)
        {
        }

        protected override void OnValueChanged(bool value)
        {
            _animator.SetBool(_hash, _value);
        }

        protected override AnimatorControllerParameterType ParamType => AnimatorControllerParameterType.Bool;
    }
}
