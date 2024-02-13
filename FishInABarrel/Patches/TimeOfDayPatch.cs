using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch]
	internal class TimeOfDayPatch
	{
		[HarmonyPatch(typeof(TimeOfDay), "UpdateProfitQuotaCurrentTime")]
		[HarmonyPostfix]
		private static void onUpdateProfitQuotaCurrentTime()
		{
			TimeOfDay.Instance.timeUntilDeadline = (int)(TimeOfDay.Instance.totalTime * TimeOfDay.Instance.quotaVariables.deadlineDaysAmount);
			StartOfRound.Instance.deadlineMonitorText.text = "DEADLINE:\n FISH";

		}
	}
}
