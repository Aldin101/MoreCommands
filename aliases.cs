using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCommands
{
    public partial class MoreCommands
    {
        [HarmonyPatch(typeof(ac_DevConsole), "Submit")]
        public class DevConsolePatch
        {
            public static void Prefix(ac_DevConsole __instance, ref string ConsoleSubmission)
            {
                string trimmedSubmission = ConsoleSubmission.Replace("white ", "").Replace("blue ", "").Replace("purple ", "").Replace("gold ", "");

                if (trimmedSubmission != ConsoleSubmission)
                {
                    List<WeaponItem> guns = GameObject.FindAnyObjectByType<InventoryScript>().Guns;

                    foreach (WeaponItem gun in guns)
                    {
                        if (trimmedSubmission.ToLower() != (gun.GenericName.ToLower()) && trimmedSubmission.ToLower() != (gun.SpecialName.ToLower())) continue;

                        if (ConsoleSubmission.ToLower().Contains("white"))
                        {
                            ConsoleSubmission = "white " + guns.IndexOf(gun);
                            continue;
                        }

                        if (ConsoleSubmission.ToLower().Contains("blue"))
                        {
                            ConsoleSubmission = "blue " + guns.IndexOf(gun);
                            continue;
                        }

                        if (ConsoleSubmission.ToLower().Contains("purple"))
                        {
                            ConsoleSubmission = "purple " + guns.IndexOf(gun);
                            continue;
                        }

                        if (ConsoleSubmission.ToLower().Contains("gold"))
                        {
                            ConsoleSubmission = "gold " + guns.IndexOf(gun);
                            continue;
                        }
                    }
                }


                if (ConsoleSubmission.ToLower().Contains("equip"))
                {
                    List<EquipmentItem> equipments = GameObject.FindAnyObjectByType<InventoryScript>().Equipment;

                    foreach (EquipmentItem equipment in equipments)
                    {
                        if (!ConsoleSubmission.ToLower().Contains(equipment.EquipmentName.ToLower())) continue;
                        ConsoleSubmission = "equip " + equipments.IndexOf(equipment);
                    }
                }

                if (ConsoleSubmission.ToLower().Contains("melee"))
                {
                    List<MeleeItem> melees = GameObject.FindAnyObjectByType<InventoryScript>().Melee;

                    foreach (MeleeItem melee in melees)
                    {
                        if (!ConsoleSubmission.ToLower().Contains(melee.MeleeName.ToLower())) continue;
                        ConsoleSubmission = "melee " + melees.IndexOf(melee);
                    }
                }
            }
        }
    }
}
