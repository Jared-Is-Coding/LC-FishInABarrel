using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(TimeOfDay))]
	internal class TimeOfDayPatch
	{
		[HarmonyPatch("UpdateProfitQuotaCurrentTime")]
		[HarmonyPostfix]
		private static void OnUpdateProfitQuotaCurrentTime()
		{
			TimeOfDay.Instance.timeUntilDeadline = (int)(TimeOfDay.Instance.totalTime * TimeOfDay.Instance.quotaVariables.deadlineDaysAmount);
			StartOfRound.Instance.deadlineMonitorText.text = "LIKE FISH\n     IN A\n   BARREL";
		}
	}
}
