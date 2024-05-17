namespace MoreCommands
{
    public partial class MoreCommands
    {
        public void godmode(string command)
        {
            GTTOD_HealthScript health = FindAnyObjectByType<GTTOD_HealthScript>();
            
            health.Invincible = !health.Invincible;

            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (hud != null)
            {
                hud.CenterPopUp("GODMODE " + (health.Invincible ? "ENABLED" : "DISABLED"), 20, 3f);
            }
        }
    }
}