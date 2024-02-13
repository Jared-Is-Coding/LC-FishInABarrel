using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(FlashlightItem))]
	internal class FlashlightItemPatch
	{
		[HarmonyPatch("Start")]
		[HarmonyPostfix]
		private static void OnStart(ref Item ___itemProperties)
		{
			___itemProperties.requiresBattery = false;

		}
	}
}
