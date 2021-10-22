using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGame.Damage
{
    public class DamageDealer : MonoBehaviour, IDamageDealer
    {
        public event EventHandler<DamageEventArgs> OnDealtDamage;
        public List<IDamageMod> Mods { get; private set; } = new List<IDamageMod>();
        public void DealDamage(DamageEventArgs damageEvent)
        {
            OnDealtDamage?.Invoke(this, damageEvent);
        }
    }
}
