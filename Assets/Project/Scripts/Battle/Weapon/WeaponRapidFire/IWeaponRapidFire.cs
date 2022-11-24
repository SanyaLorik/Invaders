namespace Invaders.Battle
{
    public interface IWeaponRapidFire : IWeaponFire
    {
        float ShootedDelay { get; }
    }
}