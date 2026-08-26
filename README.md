# Forest Survival

## Overview

**Forest Survival** is a 3D survival and exploration game developed in Unity. The player explores a forest, gathers resources, crafts a sword, manages health, avoids hazards, and defeats a dangerous bear to complete the game. This is a Final Project for COMP5970, Game Development, Dr. Abhishek Jariwala, Auburn University.

## Screenshots
<img width="993" height="558" alt="image" src="https://github.com/user-attachments/assets/f6a876b1-3fbf-41b7-ad82-60869cfba2c9" />
<img width="991" height="549" alt="image" src="https://github.com/user-attachments/assets/4647adac-d349-4424-9d71-3de7450061f1" />
<img width="977" height="557" alt="image" src="https://github.com/user-attachments/assets/f61f8a7a-db78-491c-8c9d-19e13daa49db" />
<img width="976" height="558" alt="image" src="https://github.com/user-attachments/assets/9082f6aa-01ef-41eb-8c10-553ee3b11ef2" />
<img width="983" height="546" alt="image" src="https://github.com/user-attachments/assets/6fbac30a-df1c-4e55-a0a4-a3e93fd62d5e" />
<img width="972" height="552" alt="image" src="https://github.com/user-attachments/assets/d28cd4a1-1af0-4c6d-b402-2566372e2cdb" />
<img width="977" height="553" alt="image" src="https://github.com/user-attachments/assets/e44056ba-235c-4ea1-96fb-29bd4e678e76" />
<img width="977" height="551" alt="image" src="https://github.com/user-attachments/assets/8cbd71d1-7c2e-42bc-b825-8bf5cab9e65f" />







## Gameplay Objective

The player must:

1. Explore the forest.
2. Gather wood, ore, crystals, and apples.
3. Collect enough materials to craft a sword.
4. Equip the sword.
5. Defeat the bear.

The sword requires:

- 5 Wood
- 3 Ore
- 2 Crystals

## Features

### Exploration

- 3D forest environment
- Third-person player movement
- Camera follow system
- Mini-map for navigation
- Day and night atmosphere

### Resource Gathering

Players can collect:

- Wood
- Ore
- Crystals
- Apples

Collected items are stored in the inventory.

### Inventory System

- Grid-based inventory
- Stackable items
- Item icons
- Starting axe
- Resource tracking

### Crafting System

Players can interact with the crafting table after collecting the required materials. Crafting the sword removes the required resources from the inventory.

### Combat System

- Equip an axe or sword
- Attack using the left mouse button
- Fight the bear
- Defeat the bear to win

### Health System

- The player begins with 100 health
- Bear attacks and environmental hazards deal damage
- Apples can be consumed to restore health
- The game ends when the player's health reaches zero

### Bear AI

The bear can:

- Patrol the forest
- Detect the player
- Chase the player
- Attack when the player is in range
- Lose interest when the player escapes
- Take damage and be defeated

### Objective System

The objective UI displays:

- Required crafting materials
- Current resource amounts
- Crafting progress
- Combat instructions after the sword is crafted
- The final objective to defeat the bear

### Audio

- Background music
- Sword attack sound effects
- Bear attack sound effects
- Apple eating sound effects
- Environmental audio

## Controls

| Action | Control |
|---|---|
| Move | W, A, S, D |
| Look Around | Mouse |
| Jump | Space |
| Run | Shift |
| Interact | E |
| Equip Axe | 1 |
| Equip Sword | 2 |
| Consume Apple | 3 |
| Attack | Left Mouse Button |
| Open Inventory | Tab |
| Restart Game | R |

## Challenge Systems

### Bear Enemy AI

The bear patrols, detects, chases, and attacks the player. The player must survive its attacks and defeat it using the crafted sword.

### Environmental Hazards

Damage hazards are placed throughout the environment. The player must avoid them while exploring and collecting resources.

### Health and Resource Management

The player has limited health and must collect and consume apples to recover from damage. Players must manage healing resources while surviving combat and hazards.

## Win and Lose Conditions

### Win Condition

The player wins by crafting a sword and defeating the bear.

### Lose Condition

The player loses when their health reaches zero.

After winning or losing, the player can press **R** to restart the game.

## Built With

- Unity 6
- C#
- Unity Input System
- TextMeshPro
- Unity NavMesh
- Universal Render Pipeline

## Asset Credits

### Audio

- [Free 25 Fantasy RPG Game Tracks Vol. 2](https://alkakrab.itch.io/free-25-fantasy-rpg-game-tracks-no-copyright-vol-2)
- [Mixkit Eating Sound Effects](https://mixkit.co/free-sound-effects/eat/)
- [Free Fantasy 200 SFX Pack](https://tommusic.itch.io/free-fantasy-200-sfx-pack)
- [Mixkit Animal Sound Effects](https://mixkit.co/free-sound-effects/animals/?page=2)
- [Middle Age Medieval Action Sound FX Pack](https://assetstore.unity.com/packages/audio/sound-fx/middle-age-medieval-action-sound-fx-pack-54030)

### Characters, Clothing, and Weapons

- [KayKit Adventurers](https://kaylousberg.itch.io/kaykit-adventurers)
- [Quaternius Modular Character Outfits: Fantasy](https://quaternius.itch.io/modular-character-outfits-fantasy)
- [Quaternius Universal Base Characters](https://quaternius.itch.io/universal-base-characters)
- [Mixamo](https://www.mixamo.com/#/?page=2&type=Character)
- [Free Stylized Bear RPG Forest Animal](https://assetstore.unity.com/packages/3d/characters/animals/free-stylized-bear-rpg-forest-animal-228910)
- [Free Pack of Medieval Weapons](https://assetstore.unity.com/packages/3d/props/weapons/free-pack-of-medieval-weapons-136607)

### Environment, Objects, and UI

- [Kenney Platformer Kit](https://kenney.nl/assets/platformer-kit)
- [2D Strategy Game Icons](https://assetstore.unity.com/packages/2d/gui/icons/2d-strategy-game-icons-281449)
- [Low Poly Environment Nature Pack](https://assetstore.unity.com/packages/3d/environments/low-poly-environment-nature-free-lowpoly-medieval-fantasy-series-187052)

## Author

**Adam Lee**  
Auburn University  
Computer Science, '27

Dr. Abhishek Jariwala is also given credit for COMP5970, Game Development, Summer 2026 modules 0-10.

