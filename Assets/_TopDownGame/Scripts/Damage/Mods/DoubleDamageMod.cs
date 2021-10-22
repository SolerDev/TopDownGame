namespace TopDownGame.Damage
{
    public class DoubleDamageMod : DamageMod
    {
        public override int Mod(DamageEventArgs damageEvent)
        {
            return damageEvent.FinalDamage * 2;
        }
    }
}
