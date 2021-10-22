namespace TopDownGame.Damage
{
    public interface IDamageMod
    {
        int Mod(DamageEventArgs damageEvent);
    }
}