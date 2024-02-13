using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch]
	internal class InverseTeleporterPatch
	{
		[HarmonyPatch(typeof(ShipTeleporter), "Awake")]
		[HarmonyPostfix]
		private static void Awake(bool ___isInverseTeleporter, ref float ___cooldownAmount, ref float ___cooldownTime)
		{
			if (___isInverseTeleporter)
			{
				___cooldownAmount = 0f;
				___cooldownTime = 0f;
			}
		}
	}
}
