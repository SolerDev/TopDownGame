using TopDownGame.Damage;
using TopDownGame.Interactions;
using UnityEngine;

namespace TopDownGame
{
    [RequireComponent(typeof(IDamageEventTrigger)
                    , typeof(IDamageDealer)
                    , typeof(IModifyDamage))]
    public class OnInteractedTriggerDamage : OnInteractedEvent
    {
        [SerializeField] private int _baseDamage = 5;

        private IDamageEventTrigger _damageEventTrigger;
        private IModifyDamage _damageModifier;
        private IDamageDealer _damageDealer;

        private void Awake()
        {
            _damageEventTrigger = GetComponent<IDamageEventTrigger>();
            _damageModifier = GetComponent<IModifyDamage>();
            _damageDealer = GetComponent<IDamageDealer>();
        }

        protected override void OnInteracted(IInteractible interactible)
        {
            _damageEventTrigger.Trigger(_damageDealer,
                                        interactible.GetComponent<ITarget>(),
                                        _baseDamage,
                                        _damageModifier.Mods);
        }
    }
}
