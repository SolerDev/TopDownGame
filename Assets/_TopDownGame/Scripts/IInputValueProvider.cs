using UnityEngine;

namespace TopDownGame.Inputs
{
    public interface IInputValueProvider
    {
        Vector2 InputDirection { get; }
    }
}