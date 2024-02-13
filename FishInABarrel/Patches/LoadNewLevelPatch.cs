using HarmonyLib;

namespace FishInABarrel.Patches
{
	[HarmonyPatch]
	internal class LoadNewLevelPatch
	{
		[HarmonyPatch(typeof(RoundManager), "LoadNewLevel")]
		[HarmonyPrefix]
		private static bool OnLoadNewLevel(ref SelectableLevel newLevel)
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
