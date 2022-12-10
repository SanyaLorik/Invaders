using Invaders.Battle;
using TMPro;

namespace Invaders.Ui
{
    public class UiWeapon
    {
        private readonly TMP_Text _text;
        private readonly IWeaponAmmoInformationProvider _provider;

        public UiWeapon(TMP_Text text, IWeaponAmmoInformationProvider provider)
        {
            _text = text;
            _provider = provider;
        }

        public void Enable() =>
            _provider.OnNumberOfBulletChanged += Change;

        public void Disable() =>
            _provider.OnNumberOfBulletChanged -= Change;

        private void Change(int current, int magazin) =>
            _text.text = $"{current} / {magazin}";
    }
}