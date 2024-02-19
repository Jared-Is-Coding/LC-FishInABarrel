using GameNetcodeStuff;
using HarmonyLib;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace FishInABarrel.Patches
{
    /// <summary>
    /// Remove inverse teleporter cooldown | Inverse teleporter does not remove player inventory
    /// </summary>
    [HarmonyPatch(typeof(ShipTeleporter))]
	internal class ShipTeleporterPatch
    {
		[HarmonyPatch("Awake")]
		[HarmonyPostfix]
		private static void PostAwake(bool ___isInverseTeleporter, ref float ___cooldownAmount, ref float ___cooldownTime)
		{
			if (___isInverseTeleporter)
			{
				___cooldownAmount = 0f;
				___cooldownTime = 0f;
			}
		}

        [HarmonyPrefix]
		[HarmonyPatch("TeleportPlayerOutWithInverseTeleporter")]
		public static bool PreTeleportPlayerOutWithInverseTeleporter(int playerObj, ref Vector3 teleportPos, ShipTeleporter __instance)
        {
            // Grab private internal methods
            MethodInfo teleportBodyOut = typeof(ShipTeleporter).GetMethod("teleportBodyOut", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo SetPlayerTeleporterId = typeof(ShipTeleporter).GetMethod("SetPlayerTeleporterId", BindingFlags.NonPublic | BindingFlags.Instance);

            // Handle dead bodies
            if (StartOfRound.Instance.allPlayerScripts[playerObj].isPlayerDead)
            {
                __instance.StartCoroutine((IEnumerator)teleportBodyOut.Invoke(__instance, new object[] { playerObj, teleportPos }));

                return false;
            }

            // Update teleporter instance
            PlayerControllerB playerControllerB = StartOfRound.Instance.allPlayerScripts[playerObj];
            SetPlayerTeleporterId.Invoke(__instance, new object[] { playerControllerB, -1 });

            // Update reverb
            if ((bool)Object.FindObjectOfType<AudioReverbPresets>())
            {
                Object.FindObjectOfType<AudioReverbPresets>().audioPresets[2].ChangeAudioReverbForPlayer(playerControllerB);
            }

            // Update player
            playerControllerB.isInElevator = false;
            playerControllerB.isInHangarShipRoom = false;
            playerControllerB.isInsideFactory = true;
            playerControllerB.averageVelocity = 0f;
            playerControllerB.velocityLastFrame = Vector3.zero;

            // Teleport
            StartOfRound.Instance.allPlayerScripts[playerObj].TeleportPlayer(teleportPos);

            // Play audio
            StartOfRound.Instance.allPlayerScripts[playerObj].beamOutParticle.Play();
            __instance.shipTeleporterAudio.PlayOneShot(__instance.teleporterBeamUpSFX);
            StartOfRound.Instance.allPlayerScripts[playerObj].movementAudio.PlayOneShot(__instance.teleporterBeamUpSFX);

            // Shake the screen
            if (playerControllerB == GameNetworkManager.Instance.localPlayerController)
            {
                HUDManager.Instance.ShakeCamera(ScreenShakeType.Big);
            }

            // Don't run the normal teleport
            return false;
        }
    }
}
