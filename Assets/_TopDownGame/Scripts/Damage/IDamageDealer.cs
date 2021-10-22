namespace TopDownGame.Damage
{
    public interface IDamageDealer : IModifyDamage, IHaveDealDamageEvents
    {
        void DealDamage(DamageEventArgs damageEvent);
    }
}