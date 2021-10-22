using System;

namespace TopDownGame.Interactions
{
    public interface IMono
    {
        T GetComponent<T>();
    }

    public interface IInteractible : IMono, IDetectable
    {
        event Action<IActor> OnWasInteracted;

        void Interact(IActor interactor);
    }
}