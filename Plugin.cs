using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx;
using HarmonyLib;
using K8Lib;

namespace MoreCommands
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("K8Lib")]
    public partial class MoreCommands : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"{PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION} has loaded!");

            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            ConsoleCommand loadLevelCommand = new ConsoleCommand("loadLevel", loadLevel);
            ConsoleCommand loadlevelCommand = new ConsoleCommand("loadlevel", loadLevel);

            ConsoleCommand loadLevelAddCommand = new ConsoleCommand("loadLevelAdd", loadLevelAdd);
            ConsoleCommand loadleveladdCommand = new ConsoleCommand("loadleveladd", loadLevelAdd);

            ConsoleCommand toggleAspect = new ConsoleCommand("aspects", aspects);

            ConsoleCommand toggleRune = new ConsoleCommand("runes", runes);

            ConsoleCommand godmodeCommand = new ConsoleCommand("godmode", godmode);

            ConsoleCommand healCommand = new ConsoleCommand("heal", heal);
            ConsoleCommand hurtCommand = new ConsoleCommand("hurt", hurt);
            ConsoleCommand SuicideCommand = new ConsoleCommand("suicide", suicide);

            ConsoleCommand statusCommand = new ConsoleCommand("status", givePowerup);
            ConsoleCommand maxAmmoCommand = new ConsoleCommand("maxAmmo", givePowerup);
            ConsoleCommand maxammoCommand = new ConsoleCommand("maxammo", givePowerup);

            ConsoleCommand noclipCommand = new ConsoleCommand("noclip", noclip);
        }

        private void Update()
        {
            noclipUpdate();
        }

        private void OnDestroy()
        {
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.UnpatchSelf();
        }
        
        private string ParseCommand(string command)
        {
            int firstSpaceIndex = command.IndexOf(' ');
            if (firstSpaceIndex >= 0 && firstSpaceIndex < command.Length - 1)
            {
                return command.Substring(firstSpaceIndex + 1).ToUpper();
            }
            else
            {
                throw new Exception("Invalid command syntax: " + command);
            }
        }
    }
}