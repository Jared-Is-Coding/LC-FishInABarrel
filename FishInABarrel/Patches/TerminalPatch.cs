using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(Terminal))]
	internal class TerminalPatch
	{
		[HarmonyPatch("BeginUsingTerminal")]
		[HarmonyPostfix]
		private static void onBeginUsingTerminal(ref int ___groupCredits)
		{
			___groupCredits = 9999;
		}
	}
}
