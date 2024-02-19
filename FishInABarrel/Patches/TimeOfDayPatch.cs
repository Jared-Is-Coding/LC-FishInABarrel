using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Infinite quota deadline
	/// </summary>
	[HarmonyPatch(typeof(TimeOfDay))]
	internal class TimeOfDayPatch
	{
		[HarmonyPatch("UpdateProfitQuotaCurrentTime")]
		[HarmonyPostfix]
		private static void PostUpdateProfitQuotaCurrentTime()
		{
			TimeOfDay.Instance.timeUntilDeadline = (int)(TimeOfDay.Instance.totalTime * TimeOfDay.Instance.quotaVariables.deadlineDaysAmount);
			StartOfRound.Instance.deadlineMonitorText.text = "LIKE FISH\n     IN A\n   BARREL";
		}
	}
}
