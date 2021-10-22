using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TopDownGame.Damage
{
    public class DamageEventTrigger : MonoBehaviour, IDamageEventTrigger
    {
        public event EventHandler<DamageEventArgs> OnTriggered;

        public void Trigger(IDamageDealer damageDealer,
                            ITarget target,
                            int baseDamage,
                            IReadOnlyCollection<IDamageMod> mods)
        {
            var damageEvent = new DamageEventArgs(damageDealer,
                                                  target,
                                                  baseDamage,
                                                  mods);

            OnTriggered?.Invoke(this, damageEvent);
        }
    }
}