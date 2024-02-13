using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(ShotgunItem))]
	internal class ShotgunItemPatch
	{
		[HarmonyPatch("ItemActivate")]
		[HarmonyPostfix]
		public static void OnItemActivate(ShotgunItem __instance)
		{
			__instance.shellsLoaded = 999;
		}

		[HarmonyPatch("ShootGun")]
		[HarmonyPostfix]
		public static void OnShootGun(ShotgunItem __instance)
		{
			__instance.shellsLoaded = 999;
		}
	}
}
