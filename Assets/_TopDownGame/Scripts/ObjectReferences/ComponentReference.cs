using UnityEngine;

namespace ObjectReferences
{
    public class ComponentReference<T> : ObjectReference<T> where T : Component
    {
        public GameObject GetGameObject()
        {
            return Get().gameObject;
        }
    }
}