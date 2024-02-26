using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreCommands {
    public partial class MoreCommands
    {
        public void loadLevel(string command)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();
            if (SceneManager.GetSceneByName(ParseCommand(command)).isLoaded)
            {
                if (hud != null)
                {
                    hud.CenterPopUp("Level already loaded", 20, 3f);
                }
                return;
            }

            if (hud != null)
            {
                hud.CenterPopUp("Loading...", 20, 3f);
            }

            SceneManager.LoadSceneAsync(ParseCommand(command), LoadSceneMode.Single);

            setSceneID(ParseCommand(command));
        }

        public void loadLevelAdd(string command)
        {
            GTTOD_HUD hud = FindAnyObjectByType<GTTOD_HUD>();

            if (SceneManager.GetSceneByName(ParseCommand(command)).isLoaded)
            {
                if (hud != null)
                {
                    hud.CenterPopUp("Level already loaded", 20, 3f);
                }
                return;
            }


            if (hud != null)
            {
                hud.CenterPopUp("Loading...", 20, 3f);
            }

            SceneManager.LoadSceneAsync(ParseCommand(command), LoadSceneMode.Additive);
        }


        public void setSceneID(string sceneName)
        {
            int sceneID = 0;
            GameObject GTTOD = GameManager.GM.gameObject;

            bool lostPath = GTTOD.GetComponent<GTTOD_UpgradesManager>().AttunementRunes[0].RuneActive;

            if (lostPath)
            {
                switch (sceneName)
                {
                    case "DEAD MANS DEPOT":
                        sceneID = 0;
                        break;
                    case "YONDER WILLOW":
                        sceneID = 1;
                        break;
                    case "AMBER VALE":
                        sceneID = 2;
                        break;
                    case "ASHWOOD THICKET":
                        sceneID = 3;
                        break;
                    case "FORGED PASS":
                        sceneID = 4;
                        break;
                    case "TIMBER HUSK":
                        sceneID = 5;
                        break;
                    case "HOLLOW VALLY":
                        sceneID = 6;
                        break;
                    case "ELDER ISLE":
                        sceneID = 7;
                        break;
                    case "THE BLADE SENTINEL":
                        sceneID = 8;
                        break;
                    case "SLUMBERING SPRING":
                        sceneID = 9;
                        break;
                    case "STEPPING STONES":
                        sceneID = 10;
                        break;
                    case "FRACTURED RIDGE":
                        sceneID = 11;
                        break;
                    case "KINDLESS KARST":
                        sceneID = 12;
                        break;
                    case "GLASS HIGHWAY":
                        sceneID = 13;
                        break;
                    case "RUGGED GULCH":
                        sceneID = 14;
                        break;
                    case "CINDER CITY":
                        sceneID = 15;
                        break;
                    case "THE LEGION SENTINEL":
                        sceneID = 16;
                        break;
                    case "TAVERN IN THE VEIL OF DISTANT WOES":
                        sceneID = 17;
                        break;
                    case "THE SUMMIT":
                        sceneID = 18;
                        break;
                    default:
                        sceneID = 0;
                        break;
                }
            }
            else
            {
                switch (sceneName)
                {
                    case "DEAD MANS DEPOT":
                        sceneID = 0;
                        break;
                    case "YONDER WILLOW":
                        sceneID = 1;
                        break;
                    case "AMBER VALE":
                        sceneID = 1;
                        break;
                    case "ASHWOOD THICKET":
                        sceneID = 1;
                        break;
                    case "FORGED PASS":
                        sceneID = 2;
                        break;
                    case "TIMBER HUSK":
                        sceneID = 2;
                        break;
                    case "HOLLOW VALLY":
                        sceneID = 3;
                        break;
                    case "ELDER ISLE":
                        sceneID = 3;
                        break;
                    case "THE BLADE SENTINEL":
                        sceneID = 4;
                        break;
                    case "SLUMBERING SPRING":
                        sceneID = 5;
                        break;
                    case "STEPPING STONES":
                        sceneID = 6;
                        break;
                    case "FRACTURED RIDGE":
                        sceneID = 6;
                        break;
                    case "KINDLESS KARST":
                        sceneID = 7;
                        break;
                    case "GLASS HIGHWAY":
                        sceneID = 7;
                        break;
                    case "RUGGED GULCH":
                        sceneID = 8;
                        break;
                    case "CINDER CITY":
                        sceneID = 8;
                        break;
                    case "THE LEGION SENTINEL":
                        sceneID = 9;
                        break;
                    case "TAVERN IN THE VEIL OF DISTANT WOES":
                        sceneID = 10;
                        break;
                    case "THE SUMMIT":
                        sceneID = 11;
                        break;
                    default:
                        sceneID = 0;
                        break;
                }
            }
            GTTOD.GetComponent<GTTOD_Manager>().SceneID = sceneID;
        }
    }
}