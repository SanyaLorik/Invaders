namespace Invaders.Battle
{
    public interface IWeaponTappingFire : IWeaponFire
    {
        float TappedDelay { get; }
    }
}