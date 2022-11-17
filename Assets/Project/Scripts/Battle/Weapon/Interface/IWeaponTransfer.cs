using Invaders.Additional;

namespace Invaders.Battle
{
    public interface IWeaponTransfer : ITransfer
    {
        IWeapon Weapon { get; }
    }
}