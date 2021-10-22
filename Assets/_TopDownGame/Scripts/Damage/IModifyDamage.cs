using System.Collections.Generic;

namespace TopDownGame.Damage
{
    public interface IModifyDamage
    {
        List<IDamageMod> Mods { get; }
    }
}