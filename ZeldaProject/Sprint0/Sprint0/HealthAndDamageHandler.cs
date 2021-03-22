using System;
namespace Sprint0
{
    public class HealthAndDamageHandler
    {
        private int damage;
        private int currentHealth;
        private int maxHealth;

        public HealthAndDamageHandler(int health, int damage)
        {
            maxHealth = health;
            currentHealth = health;
            this.damage = damage;
        }

        public bool IsAlive()
        {
            return currentHealth > 0;
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

        public int DealDamage()
        {
            return damage;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }
    }
}
