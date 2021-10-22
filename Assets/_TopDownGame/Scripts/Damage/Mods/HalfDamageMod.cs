using UnityEngine;

namespace TopDownGame.Damage
{
    public class HalfDamageMod : DamageMod
    {
        public override int Mod(DamageEventArgs damageEvent)
        {
            return Mathf.RoundToInt(damageEvent.FinalDamage / 2f);
        }
    }
}
