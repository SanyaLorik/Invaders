using Invaders.Battle;

namespace Invaders.Gear
{
    public abstract class WeaponCarrier : Carrier<IWeaponPortable>
    {
        protected abstract void Arm(IWeapon weapon);
    }
}