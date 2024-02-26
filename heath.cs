namespace MoreCommands
{
    public partial class MoreCommands
    {
        public void heal(int value)
        {
            GTTOD_HealthScript health = FindAnyObjectByType<GTTOD_HealthScript>();
            
            health.Heal(value, true);
        }
        
        public void hurt(int value)
        {
            GTTOD_HealthScript health = FindAnyObjectByType<GTTOD_HealthScript>();

            health.Damage(value);
        }

        public void suicide(string value)
        {
            GTTOD_HealthScript health = FindAnyObjectByType<GTTOD_HealthScript>();

            health.Die();
        }
    }
}
