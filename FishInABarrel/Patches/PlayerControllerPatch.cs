using GameNetcodeStuff;
using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(PlayerControllerB))]
	internal class PlayerControllerPatch
	{
		[HarmonyPatch("Update")]
		[HarmonyPostfix]
		private static void onUpdate(ref float ___sprintMeter)
		{
			___sprintMeter = 1f;
		}
	}
}
