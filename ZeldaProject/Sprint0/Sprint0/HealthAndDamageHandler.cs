using System;
namespace Sprint0
{
    public class HealthAndDamageHandler
    {
        private int damageValue;
        private int currentHealth;
        private int maxHealth;

        public HealthAndDamageHandler(int health, int damage)
        {
            maxHealth = health;
            currentHealth = health;
            damageValue = damage;
        }

        public bool IsAlive()
        {
            return currentHealth > 0;
        }

        public int Health()
        {
            return currentHealth;
        }

        public void GetDamaged(int damageAmount)
        {
            currentHealth -= damageAmount;
        }

        public void Heal(int health)
        {
            currentHealth += health;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void SetHealth(int health)
        {
            currentHealth = 0;
            Heal(health);
        }

        public void ChangeMaxHealth(int newHealth)
        {
            maxHealth = newHealth;
        }

        public bool AtMaxHealth()
        {
            return maxHealth == currentHealth;
        }

        public int DealDamage()
        {
            return damageValue;
        }

        public void SetDamage(int damage)
        {
            damageValue = damage;
        }
    }
}
