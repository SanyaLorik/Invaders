using Invaders.Additional;

namespace Invaders.Battle
{
    public interface IWeaponPortable : IPortable
    {
        IWeapon Weapon { get; }
    }
}