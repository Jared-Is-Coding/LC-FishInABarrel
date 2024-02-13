using LethalLib.Modules;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishInABarrel.Patches
{
	internal class StorePatch
	{
		public static void OnLoaded(Scene scene, LoadSceneMode mode)
		{
			// Create the shotgun object
			Item shotgunItem = Object.Instantiate(getItem("Shotgun"));
			shotgunItem.name = "Shotgun";
			shotgunItem.isScrap = false;
			shotgunItem.creditsWorth = 10;

			// Configure terminal information
			TerminalNode shotgunTerminalNode = ScriptableObject.CreateInstance<TerminalNode>();
			shotgunTerminalNode.name = "ShotgunInfoNode";
			shotgunTerminalNode.displayText = "Like shooting fish in a barrel\n\n";
			shotgunTerminalNode.clearPreviousText = true;
			shotgunTerminalNode.maxCharactersToType = 25;

			// Register to the shop
			Items.RegisterShopItem(shotgunItem, null, null, shotgunTerminalNode, 10);
		}

		private static Item getItem(string Value)
		{
			Item[] array = Resources.FindObjectsOfTypeAll<Item>();

			foreach (Item item in array)
			{
				if (item.name == Value)
				{
					return item;
				}
			}

			return null;
		}
	}
}
