using HarmonyLib;
using System;
using System.Reflection;

namespace FishInABarrel.Patches
{
    /// <summary>
    /// Inverse teleporter is on the ship at the beginning of the game
    /// </summary>
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        private static readonly string INVERSE_TP = "Inverse Teleporter";
        private static bool isInitialized;
        private static bool isLoaded;
        private static int inverseTeleporterID = -1;

        [HarmonyPatch("SetDiscordStatusDetails")]
        [HarmonyPostfix]
        private static void PostUpdate(ref StartOfRound __instance)
        {
            if (isLoaded) return;
            if (!__instance.IsHost) return;

            // Get inverse teleporter object instance ID
            if (!isInitialized)
            {
                for (var i = 0; i < __instance.unlockablesList.unlockables.Count; i++)
                {
                    var unlockableItem = __instance.unlockablesList.unlockables[i];
                    var itemName = unlockableItem.unlockableName.ToLower();

                    if (itemName.Equals(INVERSE_TP.ToLower()))
                    {
                        inverseTeleporterID = i;
                    }
                }

                isInitialized = true;
            }

            // Spawn inverse teleporter
            if (inverseTeleporterID != -1)
            {
                var unlockShipMethod = __instance.GetType().GetMethod("UnlockShipObject", BindingFlags.NonPublic | BindingFlags.Instance);
                unlockShipMethod.Invoke(__instance, new object[] { inverseTeleporterID });
            }

            isLoaded = true;
        }
    }
}
