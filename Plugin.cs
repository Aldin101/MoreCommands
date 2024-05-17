using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx;
using HarmonyLib;
using K8Lib.Commands;

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
        }

        private void Start()
        {
            new ConsoleCommand("loadlevel", loadLevel);
            new ConsoleCommand("loadadd", loadLevelAdd);
            new PostfixConsoleCommand("aspects", aspects);
            new ConsoleCommand("runes", runes);
            new ConsoleCommand("godmode", godmode);
            new ConsoleCommand("heal", heal);
            new ConsoleCommand("hurt", hurt);
            new ConsoleCommand("suicide", suicide);
            new ConsoleCommand("status", givePowerup);
            new ConsoleCommand("maxammo", givePowerup);
            new ConsoleCommand("noclip", noclip);
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