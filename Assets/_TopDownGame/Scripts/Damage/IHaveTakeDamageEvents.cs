using System;

namespace TopDownGame.Damage
{
    public interface IHaveTakeDamageEvents
    {
        event EventHandler<DamageEventArgs> OnWasDamaged;
    }

}
