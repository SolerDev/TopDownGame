using TopDownGame.Interactions;
using UnityEngine;

namespace TopDownGame
{
    [RequireComponent(typeof(IActor))]
    public abstract class OnInteractedEvent : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<IActor>().OnInteracted += OnInteracted;
        }

        private void OnDisable()
        {
            GetComponent<IActor>().OnInteracted -= OnInteracted;
        }

        protected abstract void OnInteracted(IInteractible interactible);
    }
}
