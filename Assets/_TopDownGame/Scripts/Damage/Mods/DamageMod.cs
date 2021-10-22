using UnityEngine;

namespace TopDownGame.Damage
{
    [RequireComponent(typeof(IModifyDamage))]
    public abstract class DamageMod : MonoBehaviour, IDamageMod
    {
        public abstract int Mod(DamageEventArgs damageEvent);

        private void OnEnable()
        {
            GetComponent<IModifyDamage>().Mods.Add(this);
        }

        private void OnDisable()
        {
            GetComponent<IModifyDamage>().Mods.Remove(this);
        }
    }
}
