using System;

namespace TopDownGame.Damage
{
    public interface IHaveDealDamageEvents
    {
        event EventHandler<DamageEventArgs> OnDealtDamage;
    }
}
