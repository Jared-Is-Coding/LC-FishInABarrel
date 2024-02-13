using BepInEx;
using BepInEx.Logging;
using FishInABarrel.Patches;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishInABarrel
{
	[BepInPlugin(ModGUID, ModName, ModVersion)]
	public class BasePlugin : BaseUnityPlugin
	{
		private static BasePlugin Instance;

		// Base mod configuration 
		private const string ModGUID = "jarediscoding.fishinabarrel";
		private const string ModName = "FishInABarrel";
		private const string ModVersion = "1.0.3"; // This should be bumped up for every release

		// Logging
		public static ManualLogSource LogSource;

		// Harmony framework prep
		private readonly Harmony harmony = new Harmony(ModGUID);

		// Patch list
		private static readonly Type[] PatchList = new Type[]
		{
			typeof(FlashlightItemPatch), // Infinite battery
			typeof(HUDManagerPatch), // Infinite quota days, always display clock
			typeof(InverseTeleporterPatch), // Inverse teleporter cooldown
			typeof(LoadNewLevelPatch), // Remove facility enemies
			typeof(PlayerControllerPatch), // Infinite sprint
			typeof(RedLocustBeesPatch), // Remove beehives
			typeof(ShotgunItemPatch), // Infinite ammo
			typeof(StartOfRoundPatch), // Spawn inverse teleporter on round start
			typeof(TerminalPatch), // Infinite credits
			typeof(TimeOfDayPatch) // Infinite quota days
		};

		void Awake()
		{
			// Safety catch
			if (Instance == null)
			{
				Instance = this;
			}

			// Prepare logger
			LogSource = BepInEx.Logging.Logger.CreateLogSource(ModGUID);

			// -------------------------------------------------------- //
			// Harmony patches
			// -------------------------------------------------------- //

			foreach (Type thisType in PatchList)
			{
				harmony.PatchAll(thisType);
				LogSource.LogDebug($"{thisType} complete");
			}

			// -------------------------------------------------------- //
			// Add shotgun to store
			// -------------------------------------------------------- //

			SceneManager.sceneLoaded += StorePatch.OnLoaded;
			LogSource.LogDebug($"FishInABarrel.Patches.StorePatch complete");

			// -------------------------------------------------------- //
			// Inverse teleporter on load
			// -------------------------------------------------------- //

			

			// -------------------------------------------------------- //
			// NetcodePatcher
			// See: https://github.com/EvaisaDev/UnityNetcodePatcher
			// -------------------------------------------------------- //

			Type[] types = Assembly.GetExecutingAssembly().GetTypes();

			foreach (var type in types)
			{
				MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

				foreach (MethodInfo method in methods)
				{
					object[] attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);

					if (attributes.Length > 0)
					{
						method.Invoke(null, null);
					}
				}
			}

			// -------------------------------------------------------- //
			// Plugin startup completed
			// -------------------------------------------------------- //

			LogSource.LogInfo($"Load complete");
		}
	}
}
