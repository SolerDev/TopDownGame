using System;
using System.Collections.Generic;

namespace TopDownGame.Damage
{
    public class DamageEventArgs : EventArgs
    {
        public int FinalDamage { get; private set; }

        private readonly IDamageDealer _damageDealer;
        private readonly ITarget _target;
        private readonly int _baseDamage;

        private readonly IReadOnlyCollection<IDamageMod> _damageMods;

        internal DamageEventArgs(IDamageDealer damageDealer,
                               ITarget target,
                               int baseDamage,
                               IReadOnlyCollection<IDamageMod> damageMods)
        {
            _damageDealer = damageDealer;
            _target = target;
            _baseDamage = baseDamage;
            _damageMods = damageMods;
        }

        internal void Process()
        {
            UpdateFinalDamage();

            _damageDealer.DealDamage(this);
            _target.TakeDamage(this);
        }

        private void UpdateFinalDamage()
        {
            FinalDamage = _baseDamage;
            foreach (var mod in _damageMods)
                FinalDamage = mod.Mod(this);
        }
    }
}
