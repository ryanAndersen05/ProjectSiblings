using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float maxHealth = 100;

    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        checkIsDead();
    }

    public void reviveHealth(float health)
    {
        currentHealth += health;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    void checkIsDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
