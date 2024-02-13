using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch]
	internal class HUDManagerPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch(typeof(HUDManager), "Update")]
		private static bool onUpdate(ref HUDElement ___Clock)
		{
			___Clock.targetAlpha = 1f;
			return true;
		}

		[HarmonyPatch(typeof(HUDManager), "DisplayDaysLeft")]
		[HarmonyPostfix]
		public static void setDisplayDaysLeft()
		{
			(HUDManager.Instance.profitQuotaDaysLeftText).text = "999 Days Left";
			(HUDManager.Instance.profitQuotaDaysLeftText2).text = "999 Days Left";
		}
	}
}
