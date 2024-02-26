namespace MoreCommands
{
    public partial class MoreCommands
    {
        public void givePowerup(string command)
        {
            GTTOD_UpgradesManager upgrades = FindAnyObjectByType<GTTOD_UpgradesManager>();

            if (command.ToLower().Contains("maxammo"))
            {
                upgrades.AmmoCratePowerUp();
            }

            if (command.ToLower().Contains("double points"))
            {
                upgrades.ToggleDoublePoints(true);
            }

            if (command.ToLower().Contains("quad damage"))
            {
                upgrades.ToggleQuadDamage(true);
            }

            if (command.ToLower().Contains("rapid fire"))
            {
                upgrades.ToggleRapidFire(true);
            }

            if (command.ToLower().Contains("speed boost") || command.ToLower().Contains("speed"))
            {
                upgrades.ToggleSpeedBoost(true);
            }

            if (command.ToLower().Contains("burn"))
            {
                upgrades.ToggleBurn(true);
            }

            if (command.ToLower().Contains("frost"))
            {
                upgrades.ToggleFrost(true);
            }

            if (command.ToLower().Contains("static"))
            {
                upgrades.ToggleStatic(true);
            }

            if (command.ToLower().Contains("weakness"))
            {
                upgrades.ToggleWeakness(true);
            }

            if (command.ToLower().Contains("strength"))
            {
                upgrades.ChargeStrength(true);
            }

            if (command.ToLower().Contains("overcharge"))
            {
                upgrades.OverchargePowerUp();
            }

            if (command.ToLower().Contains("ammo bag"))
            {
                upgrades.AmmoBagPowerUp();
            }

            if (command.ToLower().Contains("ammo crate") || command.ToLower().Contains("ammo"))
            {
                upgrades.AmmoCratePowerUp();
            }

            if (command.ToLower().Contains("money bag") || command.ToLower().Contains("money"))
            {
                upgrades.MoneyBagPowerUp();
            }

            if (command.ToLower().Contains("obliterate"))
            {
                upgrades.ObliteratePowerUp();
            }
        }
    }
}
