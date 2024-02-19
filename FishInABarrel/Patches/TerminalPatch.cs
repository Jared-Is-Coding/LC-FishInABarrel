using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Infinite credits
	/// </summary>
	[HarmonyPatch(typeof(Terminal))]
	internal class TerminalPatch
	{
		[HarmonyPatch("BeginUsingTerminal")]
		[HarmonyPostfix]
		private static void PostBeginUsingTerminal(ref int ___groupCredits)
		{
			___groupCredits = 9999;
		}
	}
}
