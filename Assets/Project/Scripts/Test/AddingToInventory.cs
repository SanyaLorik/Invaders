using Invaders.Gear;
using UnityEngine;

namespace Invaders.Test
{
    public class AddingToInventory : MonoBehaviour
    {
        public PlayerInventory PlayerInventory;
        public Ak47Inventory Ak47;

        private void Start()
        {
            PlayerInventory.Add(Ak47);
        }
    }
}