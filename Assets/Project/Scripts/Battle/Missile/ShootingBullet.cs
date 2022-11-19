using Invaders.Pysiol;

namespace Invaders.Battle
{
    public class ShootingBullet : Missile
    {
        protected override void DealDamage(IDamageable<int> damageable, int damage) =>
            damageable.Damage(damage);
    }
}