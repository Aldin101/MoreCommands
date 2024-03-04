using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreCommands
{
    public partial class MoreCommands
    {
        private bool noclipEnabled = false;
        private string levelWhenEnabled;
        public void noclip(string command)
        {
            noclipEnabled = !noclipEnabled;

            if (noclipEnabled)
            {
                levelWhenEnabled = SceneManager.GetActiveScene().name;
            }

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

            CapsuleCollider[] capsuleColliders = FindObjectsOfType<CapsuleCollider>();
            foreach (CapsuleCollider collider in capsuleColliders)
            {
                if (collider.gameObject.tag == "Player") continue;
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
                if (SceneManager.GetActiveScene().name != levelWhenEnabled)
                {
                    controller.CharacterGroundState = ac_CharacterController.GroundState.Grounded;
                    noclipEnabled = false;

                    GTTOD_Manager manager = GameManager.GM.gameObject.GetComponent<GTTOD_Manager>();
                    GameObject waystation = manager.Waystation.gameObject;

                    MeshCollider[] meshColliders = waystation.GetComponentsInChildren<MeshCollider>();
                    foreach (MeshCollider collider in meshColliders)
                    {
                        collider.enabled = true;
                    }

                    BoxCollider[] boxColliders = waystation.GetComponentsInChildren<BoxCollider>();
                    foreach (BoxCollider collider in boxColliders)
                    {
                        collider.enabled = true;
                    }

                    CapsuleCollider[] capsuleColliders = waystation.GetComponentsInChildren<CapsuleCollider>();
                    foreach (CapsuleCollider collider in capsuleColliders)
                    {
                        collider.enabled = true;
                    }

                    return;
                }
                controller.CharacterGroundState = ac_CharacterController.GroundState.Swimming;
            }
        }
    }
}