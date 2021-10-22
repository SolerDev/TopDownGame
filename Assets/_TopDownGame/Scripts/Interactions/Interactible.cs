using System;
using UnityEngine;

namespace TopDownGame.Interactions
{
    public class Interactible : MonoBehaviour, IInteractible
    {
        public event Action<IActor> OnWasInteracted;
        public event Action<IDetect> OnWasDetected;

        public void Detect(IDetect detector)
        {
            OnWasDetected?.Invoke(detector);
        }

        public void Interact(IActor interactor)
        {
            OnWasInteracted?.Invoke(interactor);
        }
    }
}