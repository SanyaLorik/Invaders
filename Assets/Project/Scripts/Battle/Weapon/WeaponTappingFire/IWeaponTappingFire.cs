namespace Invaders.Battle
{
    public interface IWeaponTappingFire : IWeapon
    {
        float TappedDelay { get; }
    }
}