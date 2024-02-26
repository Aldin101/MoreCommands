using UnityEngine;

namespace MoreCommands
{
    public partial class MoreCommands
    {
        public void runes(string unused)
        {
            ac_CutsceneManager cutscene = FindAnyObjectByType<ac_CutsceneManager>();
            GameObject GTTOD = GameManager.GM.gameObject;
            GameObject player = GTTOD.transform.GetChild(0).gameObject;

            cutscene.PlayCutscene(18, player.transform.position, player.transform.rotation);
        }
    }
}