namespace Invaders.Battle
{
    public interface IWeaponFire : IWeapon, IAmmoReplenishable
    {
        void Reload();
    }
}