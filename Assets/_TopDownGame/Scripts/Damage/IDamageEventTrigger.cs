using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopDownGame.Damage
{
    public interface IDamageEventTrigger
    {
        event EventHandler<DamageEventArgs> OnTriggered;

        void Trigger(IDamageDealer damageDealer
                    , ITarget target
                    , int baseDamage
                    , IReadOnlyCollection<IDamageMod> mods);
    }
}