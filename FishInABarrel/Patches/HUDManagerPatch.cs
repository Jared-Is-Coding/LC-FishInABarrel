using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(HUDManager))]
	internal class HUDManagerPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("Update")]
		private static bool OnUpdate(ref HUDElement ___Clock)
		{
			___Clock.targetAlpha = 1f;
			return true;
		}

		[HarmonyPatch("DisplayDaysLeft")]
		[HarmonyPostfix]
		public static void SetDisplayDaysLeft()
		{
			HUDManager.Instance.profitQuotaDaysLeftText.text = "999 Days Left";
			HUDManager.Instance.profitQuotaDaysLeftText2.text = "999 Days Left";
		}
	}
}
