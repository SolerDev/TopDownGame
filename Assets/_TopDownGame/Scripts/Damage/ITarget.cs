namespace TopDownGame.Damage
{
    public interface ITarget : IModifyDamage, IHaveTakeDamageEvents
    {
        void TakeDamage(DamageEventArgs damageEvent);
    }
}
