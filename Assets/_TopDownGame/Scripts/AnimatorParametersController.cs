using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownGame
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorParametersController : MonoBehaviour
    {
        private Dictionary<string, AnimatorParameter> _paramsByName = new Dictionary<string, AnimatorParameter>();
        public IReadOnlyDictionary<string, AnimatorParameter> ParamsByName => _paramsByName;


        [Inject]
        private void Construct(/*Animator animator*/)
        {
            //todo: injetar
            var animator = transform.parent.GetComponentInChildren<Animator>();

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
    }
}
