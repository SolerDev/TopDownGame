using System;

namespace TopDownGame.Interactions
{
    public interface IDetectable
    {
        event Action<IDetect> OnWasDetected;

        void Detect(IDetect detector);
    }
}