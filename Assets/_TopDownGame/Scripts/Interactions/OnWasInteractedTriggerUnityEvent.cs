using TopDownGame.Damage;
using TopDownGame.Interactions;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownGame
{
    [RequireComponent(typeof(ITarget))]
    public class OnWasInteractedTriggerUnityEvent : OnWasInteractedWithEvent
    {
        [SerializeField] private UnityEvent _event;

        protected override void OnWasInteracted(IActor actor)
        {
            _event.Invoke();
        }
    }
}
