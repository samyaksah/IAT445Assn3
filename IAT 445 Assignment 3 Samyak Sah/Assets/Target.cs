using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f; // enemy's health
    enemyAI enemyAI;

   private void Start()
    {
        enemyAI = GetComponent<enemyAI>(); // used to access the enemy ai script
    }
    public void TakeDamage(float amount)
    {
        health -= amount; // decrease health based of number of bullets fired by the gun
        if(health <= 0f)
        {
            Die(); // call the function to kill the enemy
        }
    }


    void Die()
    {
        enemyAI.EnemyDeathAnim(); // play the emnemy death animation
        Destroy(gameObject, 2); // destroy the object after 2 sec, so that the animation can play out
    }
}
