using TopDownGame.Interactions;
using UnityEngine;

namespace TopDownGame
{
    [RequireComponent(typeof(IInteractible))]
    public abstract class OnWasInteractedWithEvent : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<IInteractible>().OnWasInteracted += OnWasInteracted;
        }

        private void OnDisable()
        {
            GetComponent<IInteractible>().OnWasInteracted -= OnWasInteracted;
        }


        protected abstract void OnWasInteracted(IActor actor);
    }
}
