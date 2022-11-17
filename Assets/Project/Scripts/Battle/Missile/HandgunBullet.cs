using Invaders.Pysiol;

namespace Invaders.Battle
{
    public class HandgunBullet : Missile
    {
        protected override void DealDamage(IDamageable<int> damageable, int damage) =>
            damageable.Damage(damage);
    }
}