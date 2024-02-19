using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Time of Day clock always visible | Infinite quota deadline
	/// </summary>
	[HarmonyPatch(typeof(HUDManager))]
	internal class HUDManagerPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("Update")]
		private static bool PreUpdate(ref HUDElement ___Clock)
		{
			___Clock.targetAlpha = 1f;
			return true;
		}

		[HarmonyPatch("DisplayDaysLeft")]
		[HarmonyPostfix]
		public static void PostDisplayDaysLeft()
		{
			HUDManager.Instance.profitQuotaDaysLeftText.text = "999 Days Left";
			HUDManager.Instance.profitQuotaDaysLeftText2.text = "999 Days Left";
		}
	}
}
