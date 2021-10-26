using System;
using UnityEngine;

namespace TopDownGame
{
    [Serializable]
    public class FloatParam : AnimatorParam<float>
    {
        public FloatParam(string name, Animator animator) : base(name, animator)
        {
        }

        protected override void OnValueChanged(float value)
        {
            _animator.SetFloat(_hash, value);
        }

        protected override AnimatorControllerParameterType ParamType => AnimatorControllerParameterType.Float;
    }
}
