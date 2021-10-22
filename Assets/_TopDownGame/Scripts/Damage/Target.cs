using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGame.Damage
{
    public class Target : MonoBehaviour, ITarget
    {
        public event EventHandler<DamageEventArgs> OnWasDamaged;
        public List<IDamageMod> Mods { get; private set; } = new List<IDamageMod>();

        public IReadOnlyCollection<IDamageMod> ReadMods => Mods;

        public void TakeDamage(DamageEventArgs damageEvent)
        {
            OnWasDamaged?.Invoke(this, damageEvent);
        }
    }
}
