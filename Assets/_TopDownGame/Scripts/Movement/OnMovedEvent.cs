using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGame
{
    public abstract class OnMovedEvent : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponentInParent<IMove>().OnMoved += OnMoved;
        }

        protected abstract void OnMoved(Vector2 movement);
    }
}
