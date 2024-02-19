using GameNetcodeStuff;
using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Infinite sprinting | Don't remove keys from player inventory on use
	/// </summary>
	[HarmonyPatch(typeof(PlayerControllerB))]
	internal class PlayerControllerBPatch
	{
		[HarmonyPatch("Update")]
		[HarmonyPostfix]
		private static void PostUpdate(ref float ___sprintMeter)
		{
			___sprintMeter = 1f;
		}

		[HarmonyPrefix]
		[HarmonyPatch("DespawnHeldObject")]
		private static bool PreDespawnHeldObject()
		{
			if (GameNetworkManager.Instance.localPlayerController.ItemSlots[GameNetworkManager.Instance.localPlayerController.currentItemSlot].GetType() == typeof(KeyItem))
			{
				return false;
			}

			return true;
		}
	}
}
