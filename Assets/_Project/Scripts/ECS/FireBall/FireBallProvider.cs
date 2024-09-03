using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Enemy;
using Assets._Project.Scripts.ECS.FireBall;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;

public class FireBallProvider : MonoProvider<FireBallComponent>
{
    protected override void Initialize()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if(other.TryGetComponent(out EnemyProvider enemyProvider))
        {
            if (enemyProvider.Entity.Has<Damagable>())
            {
                ref Damagable damagable = ref enemyProvider.Entity.GetComponent<Damagable>();
                damagable.Value += Entity.GetComponent<Damage>().Value;
            }

            Destroy(gameObject);
        }
    }
}
