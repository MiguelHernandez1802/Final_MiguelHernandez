using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    protected EnemyProfileSO data;
    protected float currentHealth;
    protected EnemyState state;

    public virtual void Initialize(EnemyProfileSO profile)
    {
        data = profile;
        currentHealth = data.health;
        state = EnemyState.Walking;
    }

    private void Update()
    {
        switch (state)
        {
            case EnemyState.Walking:
                Move();
                break;
            case EnemyState.Idle:
                break;
        }
    }

    protected abstract void Move();

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Destroy(gameObject);
    }
}