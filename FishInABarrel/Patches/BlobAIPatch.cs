using HarmonyLib;
using UnityEngine;

namespace FishInABarrel.Patches
{
	/// <summary>
	/// Remove blobs
	/// </summary>
	[HarmonyPatch(typeof(BlobAI))]
	internal class BlobAIPatch
	{
		[HarmonyPatch("Update")]
		[HarmonyPostfix]
		private static void PostUpdate()
		{
			if (GameNetworkManager.Instance.isHostingGame)
			{
				BlobAI blob = Object.FindObjectOfType<BlobAI>();

				blob.enemyType.canDie = true;
				blob.KillEnemyClientRpc(true);
				blob.KillEnemyOnOwnerClient(true);

				Object.DestroyImmediate((Object)(object)blob);
			}
		}
	}
}
