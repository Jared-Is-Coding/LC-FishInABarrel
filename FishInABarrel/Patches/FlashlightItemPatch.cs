﻿using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Infinite flashlight battery
	/// </summary>
	[HarmonyPatch(typeof(FlashlightItem))]
	internal class FlashlightItemPatch
	{
		[HarmonyPatch("Start")]
		[HarmonyPostfix]
		private static void PostStart(ref Item ___itemProperties)
		{
			___itemProperties.requiresBattery = false;

		}
	}
}
