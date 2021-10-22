using System;
using UnityEngine;

namespace TopDownGame.Interactions
{
    public class Actor : MonoBehaviour, IActor
    {
        public event Action<IInteractible> OnInteracted;
        public event Action<IDetectable> OnDetected;

        public void Detect(IDetectable detected)
        {
            OnDetected?.Invoke(detected);
        }

        public void Interact(IInteractible interactible)
        {
            OnInteracted?.Invoke(interactible);
        }
    }
}