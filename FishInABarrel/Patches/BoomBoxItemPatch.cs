using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Infinite boombox battery
	/// </summary>
	[HarmonyPatch(typeof(BoomboxItem))]
	internal class BoomBoxItemPatch
	{
		[HarmonyPatch("Start")]
		[HarmonyPostfix]
		private static void PostStart(ref Item ___itemProperties)
		{
			___itemProperties.requiresBattery = false;

		}
	}
}
