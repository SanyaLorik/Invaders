using Invaders.Gear;
using UnityEngine;

namespace Assets.Project.Scripts.Battle.Grenades
{
    public interface IGrenade : IItem
    {
        void Throw(Vector3 direction);
    }
}