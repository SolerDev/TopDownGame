using TopDownGame.Interactions;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownGame
{
    public class OnInteractTriggerUnityEvent : OnWasInteractedWithEvent
    {
        [SerializeField] private UnityEvent _event;

        protected override void OnWasInteracted(IActor actor)
        {
            _event.Invoke();
        }
    }
}
