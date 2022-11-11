namespace Invaders.Battle
{
    public interface IWeaponRapidFire : IWeapon
    {
        float ShootedDelay { get; }
    }
}