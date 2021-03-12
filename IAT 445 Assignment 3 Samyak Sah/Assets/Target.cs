using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    enemyAI enemyAI;

   private void Start()
    {
        enemyAI = GetComponent<enemyAI>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }


    void Die()
    {
        enemyAI.EnemyDeathAnim();
        Destroy(gameObject, 2);
    }
}
