using UnityEngine;

public class FastEnemy : EnemyBase
{
    public override void Initialize(EnemyProfileSO profile)
    {
        base.Initialize(profile);
        this.name = profile.enemyName;
    }

    protected override void Move()
    {
        transform.Translate(Vector3.forward * data.speed * Time.deltaTime);
    }

}
