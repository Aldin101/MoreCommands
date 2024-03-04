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

                if (ConsoleSubmission.ToLower().Contains("blessing")) {
                    GTTOD_UpgradesManager upgradesManager = GameObject.FindObjectOfType<GTTOD_UpgradesManager>();
                    List<Karma> blessings = upgradesManager.BlessedKarma;

                    foreach (Karma blessing in blessings)
                    {
                        if (!ConsoleSubmission.ToLower().Contains(blessing.KarmaName.ToLower())) continue;
                        ConsoleSubmission = "blessing " + blessings.IndexOf(blessing);
                    }
                }

                if (ConsoleSubmission.ToLower().Contains("curse"))
                {
                    GTTOD_UpgradesManager upgradesManager = GameObject.FindObjectOfType<GTTOD_UpgradesManager>();
                    List<Karma> curses = upgradesManager.CursedKarma;

                    foreach (Karma curse in curses)
                    {
                        if (!ConsoleSubmission.ToLower().Contains(curse.KarmaName.ToLower())) continue;
                        ConsoleSubmission = "curse " + curses.IndexOf(curse);
                    }
                }

                if (ConsoleSubmission.ToLower().Contains("item"))
                {
                    string[] items = GridItem.GridItemType.GetNames(typeof(GridItem.GridItemType));

                    foreach (string item in items)
                    {
                        if (!ConsoleSubmission.ToLower().Replace(" ", "").Replace("item", "").Contains(item.ToLower())) continue;

                        int itemId = (int)System.Enum.Parse(typeof(GridItem.GridItemType), item) - 1;

                        ConsoleSubmission = "item " + itemId.ToString();
                    }
                }
            }
        }
    }
}
