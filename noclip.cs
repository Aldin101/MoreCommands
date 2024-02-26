using UnityEngine;

namespace MoreCommands
{
    public partial class MoreCommands
    {
        private bool noclipEnabled = false;
        public void noclip(string command)
        {
            noclipEnabled = !noclipEnabled;

            MeshCollider[] meshColliders = FindObjectsOfType<MeshCollider>();
            foreach (MeshCollider collider in meshColliders)
            {
                collider.enabled = !collider.enabled;
            }

            BoxCollider[] boxColliders = FindObjectsOfType<BoxCollider>();
            foreach (BoxCollider collider in boxColliders)
            {
                collider.enabled = !collider.enabled;
            }


            ac_CharacterController controller = FindAnyObjectByType<ac_CharacterController>();
            controller.CharacterGroundState = ac_CharacterController.GroundState.Grounded;

        }

        private void noclipUpdate()
        {
            if (noclipEnabled)
            {
                ac_CharacterController controller = FindAnyObjectByType<ac_CharacterController>();
                controller.CharacterGroundState = ac_CharacterController.GroundState.Swimming;
            }
        }
    }
}