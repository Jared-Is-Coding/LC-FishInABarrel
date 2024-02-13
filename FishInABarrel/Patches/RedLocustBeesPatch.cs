﻿using HarmonyLib;
using UnityEngine;

namespace FishInABarrel.Patches
{
	[HarmonyPatch(typeof(RedLocustBees))]
	internal class RedLocustBeesPatch
	{
		[HarmonyPatch("Update")]
		[HarmonyPostfix]
		private static void OnUpdate()
		{
			if (GameNetworkManager.Instance.isHostingGame)
			{
				RedLocustBees redLocustBees = Object.FindObjectOfType<RedLocustBees>();

                redLocustBees.enemyType.canDie = true;
				redLocustBees.KillEnemyClientRpc(true);
				redLocustBees.KillEnemyOnOwnerClient(true);

				Object.DestroyImmediate((Object)(object)redLocustBees);
			}
		}
	}
}
