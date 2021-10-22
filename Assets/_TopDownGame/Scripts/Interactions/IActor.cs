using System;

namespace TopDownGame.Interactions
{
    public interface IActor : IDetect
    {
        event Action<IInteractible> OnInteracted;
        void Interact(IInteractible interactible);
    }
}