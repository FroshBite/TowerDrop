# TowerDrop 
#### Tower Defence + Tetris

###### Unity Setup:
		In Edit > Project Settings > Editor :
		- Set Version Control to have visible meta files
		- Set Asset Serialization Mode to "Forced Text" 
###### Tags:
  - Block
  - Bullet / Projectile
  - Skeleton / Enemies etc
  - Tower / Cannom etc

###### Layers:
  - Block
  - Block Group
  - Enemy
  - Projectiles
  - Specials
  - 

###### Naming Rules:
  - Cammel Case, All upper case ( EnemyClass.cs )
  - Specify if Class or Controller

###### Folder Layout:
  - Assets
  - Scipts
  - ???

###### Collision Matrix

| --- | Special  | Projectiles | Enemies | Block Groups | Blocks |
| --- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- |
| Blocks |   | x  | x  |   | x  |
| Block Groups |   |  | x  |  | - |
| Enemies |   | x |  | - | - |
| Projectiles |   |  |- | - | - |
| Special |   | - | - | - | - |

		
