using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreCommands
{
    public partial class MoreCommands
    {
        private bool noclipEnabled = false;
        public void noclip(string command)
        {
            noclipEnabled = !noclipEnabled;
            GameManager.GM.Player.GetComponent<Rigidbody>().detectCollisions = !noclipEnabled;
            if (!noclipEnabled)
            {
                GameManager.GM.Player.GetComponent<ac_CharacterController>().CharacterGroundState = ac_CharacterController.GroundState.Grounded;
            }
        }

        private void noclipUpdate()
        {
            if (noclipEnabled)
            {
                GameManager.GM.Player.GetComponent<ac_CharacterController>().CharacterGroundState = ac_CharacterController.GroundState.Swimming;
            }
        }
    }
}