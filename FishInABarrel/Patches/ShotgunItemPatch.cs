using HarmonyLib;

namespace FishInABarrel.Patches
{
    [HarmonyPatch]
	internal class ShotgunItemPatch
	{
		[HarmonyPatch(typeof(ShotgunItem), "ItemActivate")]
		[HarmonyPostfix]
		public static void onItemActivate(ShotgunItem __instance)
		{
			__instance.shellsLoaded = 999;
		}

		[HarmonyPatch(typeof(ShotgunItem), "ShootGun")]
		[HarmonyPostfix]
		public static void onShootGun(ShotgunItem __instance)
		{
			__instance.shellsLoaded = 999;
		}
	}
}
