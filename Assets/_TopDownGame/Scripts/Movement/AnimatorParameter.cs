using System;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace TopDownGame
{
    [Serializable]
    public abstract class AnimatorParameter
    {
        protected string _name;

        protected abstract AnimatorControllerParameterType ParamType { get; }

        protected Animator _animator;
        protected int _hash;

        protected AnimatorParameter(string name, Animator animator)
        {
            Validate(name, animator);

            _name = name;
            _animator = animator;
            _hash = Animator.StringToHash(_name);
        }

        private void Validate(string paramName, Animator animator)
        {
            try
            {
                AnimatorControllerParameter parameter = null;
                try
                {
                    parameter = animator.parameters.First(p => p.name == paramName);
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"{paramName} not found on {animator}.", e);
                }

                if (parameter.type != ParamType)
                    throw new ArgumentException($"{paramName} on {animator} is not of type {ParamType}.");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Error while validating parameter on {this}.", e);
            }
        }
    }


    [Serializable]
    public abstract class AnimatorParam<T> : AnimatorParameter
    {
        protected T _value;

        protected AnimatorParam(string name, Animator animator) : base(name, animator) { }

        public void Set(T value)
        {
            if (_value.Equals(value))
                return;

            _value = value;
            OnValueChanged(value);
        }


        protected abstract void OnValueChanged(T value);



        public T Get()
        {
            return _value;
        }

        public static implicit operator T(AnimatorParam<T> parameter)
        {
            return parameter.Get();
        }
    }
}