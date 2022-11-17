using Invaders.Battle;
using UnityEngine;

namespace Invaders.Gear
{
    public abstract class WeaponBearer : MonoBehaviour
    {
        [SerializeField] private Transform _bearer;

        private IWeapon _having;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IWeapon weapon) == false)
                return;

            if (HasWeapon == false)
            {
                FixOnBearer(collision.transform);
                Take(weapon);
            }
        }

        private bool HasWeapon => _having != null;

        private void FixOnBearer(Transform weapon)
        {
            weapon.SetParent(_bearer);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }

        protected virtual void Take(IWeapon weapon) =>
            _having = weapon;
    }
}