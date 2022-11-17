using Invaders.Additional;
using Invaders.Battle;
using UnityEngine;

namespace Invaders.Gear
{
    public abstract class WeaponBearer : MonoBehaviour
    {
        [SerializeField] private Transform _bearer;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IWeaponTransfer weaponTransfer) == false)
                return;

            if (HasWeapon == false)
            {
                Transfer = weaponTransfer;

                weaponTransfer.Take();
                FixOnBearer(collision.transform);
                Take(weaponTransfer.Weapon);
            }
        }

        protected ITransfer Transfer { get; private set; }

        protected bool HasWeapon => Transfer != null;

        private void FixOnBearer(Transform weapon)
        {
            weapon.SetParent(_bearer);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }

        protected abstract void Take(IWeapon weapon);

        protected virtual void DropWeapon() =>
            Transfer = null;
    }
}