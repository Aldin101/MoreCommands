using HarmonyLib;

namespace MoreCommands
{
    public partial class MoreCommands
    {
        public void aspects(string command)
        {
            GTTOD_UpgradesManager upgrades = FindAnyObjectByType<GTTOD_UpgradesManager>();
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            GTTOD_Manager manager = FindAnyObjectByType<GTTOD_Manager>();

            hud.ShowAspectUI = true;
            upgrades.ToggleAspects(true);
        }
    }

    [HarmonyPatch(typeof(GTTOD_UpgradesManager), "ToggleAspects")]
    public class AspectsPatch {
        public static bool originalManagerState;

        public static void Prefix(GTTOD_UpgradesManager __instance, bool AspectActive)
        {
            originalManagerState = __instance.GetComponentInParent<GTTOD_Manager>().GameStarted;
            __instance.GetComponentInParent<GTTOD_Manager>().GameStarted = false;
        }

        public static void Postfix(GTTOD_UpgradesManager __instance, bool AspectActive)
        {
            __instance.GetComponentInParent<GTTOD_Manager>().GameStarted = originalManagerState;
        }
    }
}