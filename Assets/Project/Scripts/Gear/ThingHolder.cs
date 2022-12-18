using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    public class ThingHolder : MonoBehaviour
    {
        private IPlayerThingCarier _picker;

        [Inject]
        private void Construct(IPlayerThingCarier picker) =>
            _picker = picker;
    }
}