namespace Invaders.Battle
{
    public interface IWeaponFire : IWeapon, IAmmoReplenishable, IWeaponAmmoCallback, IWeaponReloadingCallback
    {
        void Reload();

        void BreakReload();
    }
}