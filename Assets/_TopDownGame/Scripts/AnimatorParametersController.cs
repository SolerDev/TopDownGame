using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownGame
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorParametersController : MonoBehaviour
    {
        private readonly Dictionary<string, AnimatorParameter> _paramsByName = new Dictionary<string, AnimatorParameter>();

        [Inject]
        private void Construct(Animator animator)
        {
            foreach (var param in animator.parameters)
                AddParam(param, animator);
        }

        private void AddParam(AnimatorControllerParameter param, Animator animator)
        {
            string paramName = param.name;
            AnimatorParameter p = null;

            switch (param.type)
            {
                case AnimatorControllerParameterType.Float:
                    p = new FloatParam(paramName, animator);
                    break;
                case AnimatorControllerParameterType.Int:
                    p = new IntParam(paramName, animator);
                    break;
                case AnimatorControllerParameterType.Bool:
                    p = new BoolParam(paramName, animator);
                    break;
                case AnimatorControllerParameterType.Trigger:
                    p = new TriggerParam(paramName, animator);
                    break;
                default:
                    break;
            }

            _paramsByName.Add(paramName, p);
        }

        public AnimatorParam<T> GetParameter<T>(string name)
        {
            if (!_paramsByName.ContainsKey(name))
                throw new KeyNotFoundException($"Parameter {name} not found in {this}");

            try
            {
                return (AnimatorParam<T>)_paramsByName[name];
            }
            catch (Exception e)
            {
                throw new InvalidCastException($"Error while looking up {name} on {this}", e);
            }
        }
    }
}
