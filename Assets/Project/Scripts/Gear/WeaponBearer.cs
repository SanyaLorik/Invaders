using Invaders.Additional;
using Invaders.Battle;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Gear
{
    public abstract class WeaponBearer : MonoBehaviour
    {
        [SerializeField] private Collider _detector;
        [SerializeField] private Transform _bearer;

        private readonly IList<WeaponContainer> _weaponTransfers = new List<WeaponContainer>();

        private ITransfer _transfer;
        private CompositeDisposable _disposable;

        protected virtual void OnEnable()
        {
            _disposable = new CompositeDisposable();

            _detector
               .OnTriggerEnterAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.TryGetComponent(out IWeaponTransfer weaponTransfer) == false)
                       return;

                   _weaponTransfers.Add(new WeaponContainer(weaponTransfer, collision.transform));
               })
               .AddTo(_disposable);

            _detector
               .OnTriggerExitAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.TryGetComponent(out IWeaponTransfer weaponTransfer) == false)
                       return;

                   WeaponContainer container = _weaponTransfers.First(i => i.Transfer == weaponTransfer);
                   _weaponTransfers.Remove(container);
               })
               .AddTo(_disposable);
        }

        protected virtual void OnDisable() =>
            _disposable?.Dispose();

        protected bool HasNearWeapon => _weaponTransfers.Count != 0;

        protected bool HasWeaponOnBearer => _transfer != null;

        protected void Take()
        {
            WeaponContainer weaponContainer = _weaponTransfers[0];

            _transfer = weaponContainer.Transfer;

            _transfer.Take();
            FixOnBearer(weaponContainer.Position);
            Arm(weaponContainer.Transfer.Weapon);
        }

        protected void DropWeapon(Vector3 position)
        {
            _transfer.Throw(position);
            _transfer = null;
        }

        private void FixOnBearer(Transform weapon)
        {
            weapon.SetParent(_bearer);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }

        protected abstract void Arm(IWeapon weapon);
    }
}