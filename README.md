# Fish In a Barrel

[![Latest Version](https://img.shields.io/thunderstore/v/JaredIsCoding/FishInABarrel?logo=thunderstore&logoColor=white)](https://thunderstore.io/c/lethal-company/p/JaredIsCoding/FishInABarrel)
[![Total Downloads](https://img.shields.io/thunderstore/dt/JaredIsCoding/FishInABarrel?logo=thunderstore&logoColor=white)](https://thunderstore.io/c/lethal-company/p/JaredIsCoding/FishInABarrel)

A Lethal Company mod for hide and seek! Remove enemies, infinite sprint, infinite ammo, clock display, and more.

## Gameplay Modifications

- Order yourself a shotgun in the terminal and take on the role of the seeker. *It's like shooting fish in a barrel!*
- Time of Day clock always visible
- Inverse teleporter is on the ship at the beginning of the game
- Remove inverse teleporter cooldown
- Remove all facility enemies
- Remove beehives
- Infinite quota deadline
- Infinite sprinting
- Infinite shotgun ammo
- Infinite flashlight battery

## Recommended Additional Mods

Here's an r2modman profile code for your convenience, if you prefer: `018db432-cbc3-66ed-b54d-b39183a309c2`

- [MoreCompany](https://thunderstore.io/c/lethal-company/p/notnotnotswipez/MoreCompany/) - Put more fish in the barrel!
- [LethalThings](https://thunderstore.io/c/lethal-company/p/Evaisa/LethalThings/) - Add teleporters in the facility!
- [FasterItemDropship](https://thunderstore.io/c/lethal-company/p/FlipMods/FasterItemDropship/) - Get your seeking shotgun faster!
- [LateCompany](https://thunderstore.io/c/lethal-company/p/anormaltwig/LateCompany/) - Allow players to join late!
- [LC FastStartup](https://thunderstore.io/c/lethal-company/p/flerouwu/LC_FastStartup/) - Quicker game launch!
- [HideModList](https://thunderstore.io/c/lethal-company/p/Sv_Matt/HideModList/) - Hide that pesky mod list popup!
- [LCLightsStartOffMod](hthttps://thunderstore.io/c/lethal-company/p/joejoejoe/LCLightsStartOffMod/) - Hide n Seek is better in the dark!

## Suggested Hide N Seek Rules

### Hiders
- Hiders are given until 10am to hide *within* the facility
- Hiders must enter through the main entrance or inverse teleporter
- Hiders must not exit the facility after entering
- Hiders can optionally tinker with the facility by disabling light panels or removing the apparatus
- Hiders can optionally use keys
- Hiders can optionally use flashlights

### Seeker(s)
- Seekers must not enter the facility until 10am
- Seekers must not use the ship monitor to find hiders
- Seekers must only enter the facility through the main entrance
- Seekers can optionally carry a flashlight or boombox in their dedicated item slots

### Gameplay and Winning
- As a seeker, if you kill all hiders you receive a point.
- When one hider is left, the deceased hiders must vote for the ship to leave. If the remaining hider survives until the ship has left, they receive a point.
- In the event the seeker dies, all remaining hiders receive a point.
- Play as many rounds as you like. The employee with the most points at the end is the winner.

## To-Do

- Add built in points tracking
- Add overlay for points display

## Code Environment Setup

Want to extend or modify this repository? Here's some steps to get set up.

1. Clone this repository
2. In `...\FishInABarrel\FishInABarrel`, create a copy of `FishInABarrel.csproj.example` named `FishInABarrel.csproj`
3. Modify the newly copied file and replace the placeholder directory roots with your relevant file locations
    - `%GAME_LOCATION%` - Where your copy of Lethal Company is installed
    - `%USER%` - Your `C:\Users` directory
4. Install [Evaisa's UnityNetcodePatcher](https://github.com/EvaisaDev/UnityNetcodePatcher)
5. You should now be able to compile the project