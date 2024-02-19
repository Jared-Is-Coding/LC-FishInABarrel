using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Infinite shotgun ammo
	/// </summary>
	[HarmonyPatch(typeof(ShotgunItem))]
	internal class ShotgunItemPatch
	{
		[HarmonyPatch("ItemActivate")]
		[HarmonyPostfix]
		public static void PostItemActivate(ShotgunItem __instance)
		{
			__instance.shellsLoaded = 999;
		}

		[HarmonyPatch("ShootGun")]
		[HarmonyPostfix]
		public static void PostShootGun(ShotgunItem __instance)
		{
			__instance.shellsLoaded = 999;
		}
	}
}
