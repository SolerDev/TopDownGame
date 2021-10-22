using System.Collections.Generic;
using UnityEngine;

namespace TopDownGame.Damage
{
    public class DamageManager : MonoBehaviour
    {
        private static readonly List<DamageEventArgs> s_damageEvents = new List<DamageEventArgs>();

        private void Update()
        {
            if (s_damageEvents.Count == 0)
                return;

            foreach (var e in s_damageEvents)
                e.Process();

            s_damageEvents.Clear();
        }

        public void AddDamageEvent(DamageEventArgs damageEvent)
        {
            s_damageEvents.Add(damageEvent);
        }
    }
}
