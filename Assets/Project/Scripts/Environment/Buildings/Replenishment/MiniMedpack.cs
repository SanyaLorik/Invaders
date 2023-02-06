using Invaders.Entities;
using UnityEngine;

namespace Invaders.Environment.Buildings
{
    public class MiniMedpack : SingleStationaryReplenishment<IPlayer>
    {
        [SerializeField][Range(0, 20)] private int _addingHealth;

        protected override void ChangeValue(IPlayer replenishable) =>
            replenishable.Value.Add(_addingHealth);
    }
}