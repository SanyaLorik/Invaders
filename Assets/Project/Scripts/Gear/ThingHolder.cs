using Invaders.Additional;
using Invaders.Battle;
using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    [RequireComponent(typeof(ICarrier<IThingPortable<IWeapon>>))]
    public class ThingHolder : MonoBehaviour
    {
        private ICarrier<IThingPortable<IPortable>> _carier;
        private IPlayerThingCarier _picker;

        [Inject]
        private void Construct(IPlayerThingCarier picker) =>
            _picker = picker;

        private void Awake() =>
            _carier = GetComponent<ICarrier<IThingPortable<IPortable>>>();

        private void OnEnable() =>
           _picker.OnTakenOrDropped += OnChangeDropOrTake;

        private void OnDisable() =>
            _picker.OnTakenOrDropped -= OnChangeDropOrTake;

        private void OnChangeDropOrTake()
        {
            if (_carier.HasPortable == true)
            {
                Drop();
                return;
            }

            if (_carier.IsNearbyPortable == true)
                Take();
        }

        private void Drop()
        {

        }

        private void Take()
        {

        }
    }
}