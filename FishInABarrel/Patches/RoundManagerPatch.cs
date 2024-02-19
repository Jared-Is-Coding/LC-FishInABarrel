using HarmonyLib;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Remove all facility enemies
	/// </summary>
	[HarmonyPatch(typeof(RoundManager))]
	internal class RoundManagerPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("LoadNewLevel")]
		private static bool PreLoadNewLevel(ref SelectableLevel newLevel)
		{
			foreach (SpawnableEnemyWithRarity enemy in newLevel.Enemies)
			{
				enemy.rarity = 0;
			}

			foreach (SpawnableEnemyWithRarity outsideEnemy in newLevel.OutsideEnemies)
			{
				outsideEnemy.rarity = 0;
			}

			return true;
		}
	}
}
