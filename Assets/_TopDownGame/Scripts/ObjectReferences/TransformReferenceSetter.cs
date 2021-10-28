using UnityEngine;

namespace ObjectReferences
{
    public class TransformReferenceSetter : ReferenceSetter<Transform>
    {
        protected override Transform GetReference()
        {
            return transform;
        }
    }
}