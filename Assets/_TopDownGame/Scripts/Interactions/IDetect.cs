using System;

namespace TopDownGame.Interactions
{
    public interface IDetect
    {
        event Action<IDetectable> OnDetected;
        void Detect(IDetectable detected);
    }
}