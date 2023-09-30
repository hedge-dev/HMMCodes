# BlackboardStatus
Provides access to `app::player::BlackboardStatus` from Sonic Frontiers.
***
### `IS_STATE_FLAG(in_name)`
#### Description
Determines whether a state flag is set.
#### Arguments
- `in_name` - The name of an enum member from the `StateFlags` enum.
#### Return Value
A boolean value representing whether the state flag is set.
#### Example
```csharp
Code
//
    #include "BlackboardStatus" noemit
//
{
    bool isPhantomRush = IS_STATE_FLAG(IsPhantomRush);
}
```
***
### `IS_WORLD_FLAG(in_name)`
#### Description
Determines whether a world flag is set.
#### Arguments
- `in_name` - The name of an enum member from the `WorldFlags` enum.
#### Return Value
A boolean value representing whether the world flag is set.
#### Example
```csharp
Code
//
    #include "BlackboardStatus" noemit
//
{
    bool isCyberSpace = IS_WORLD_FLAG(IsCyberSpace);
}
```
***
### `struct Data`
#### Description
A struct representation of `app::player::BlackboardStatus`.
#### Members
- ##### `BlackboardContent BlackboardContent`
	- ##### Description
		An instance of `app::player::BlackboardContent`, the base class for `app::player::BlackboardStatus`.
- ##### `bool IsSuper`
	- ##### Description
		Determines if the current player is in their Super form.
- ##### `long StateFlags`
	- ##### Description
		Bit flags representing state statuses.
- ##### `long WorldFlags`
	- ##### Description
		Bit flags representing world statuses.
***
### `Data* Get()`
#### Description
Gets an instance of `app::player::BlackboardStatus`.
#### Return Value
A pointer to an instance of `app::player::BlackboardStatus`.
#### Example
```csharp
Code
//
    #lib "BlackboardStatus"
//
{
    var pBlackboardStatus = BlackboardStatus.Get();
}
```
***
### `bool IsSuper()`
#### Description
Determines if the current player is in their Super form.
#### Return Value
A boolean value representing whether the current player is in their Super form.
***
### `enum StateFlags`
#### Description
An enum containing known state flags.
#### Members
- ##### `IsBoost = 0x00`
	- ##### Description
		The player is boosting.
- ##### `IsRecoveryJump = 0x02`
	- ##### Description
		The player is performing a recovery jump.
- ##### `IsAirBoost = 0x04`
	- ##### Description
		The player is air boosting.
- ##### `IsGrindJump = 0x06`
	- ##### Description
		The player has jumped on a rail.
- ##### `IsGrind = 0x07`
	- ##### Description
		The player is grinding on a rail.
- ##### `IsJump = 0x08`
	- ##### Description
		The player is jumping.
- ##### `IsDoubleJump = 0x09`
	- ##### Description
		The player has double jumped.
- ##### `IsBounceJump = 0x0A`
	- ##### Description
		The player has stomp bounced.
- ##### `IsFall = 0x0B`
	- ##### Description
		The player is falling.
- ##### `IsStomp = 0x0C`
	- ##### Description
		The player is stomping.
- ##### `IsDiving = 0x0D`
	- ##### Description
		The player is diving.
- ##### `IsDivingBoost = 0x0E`
	- ##### Description
		The player is boosting whilst diving.
- ##### `IsCyloop = 0x11`
	- ##### Description
		The player is using Cyloop.
- ##### `IsCyloopEnd = 0x12`
	- ##### Description
		The player finished a Cyloop.
- ##### `IsDrift = 0x13`
	- ##### Description
		The player is drifting.
- ##### `IsDriftDash = 0x14`
	- ##### Description
		The player is boosting whilst drifting.
- ##### `IsHoming = 0x17`
	- ##### Description
		The player is performing a homing attack.
- ##### `IsParry = 0x18`
	- ##### Description
		The player is parrying.
- ##### `IsWallClimb = 0x19`
	- ##### Description
		The player is climbing a wall.
- ##### `IsIdle = 0x1A`
	- ##### Description
		The player is idle.
- ##### `IsBoarding = 0x1E`
	- ##### Description
		The player is using the skateboard.
- ##### `IsSpringJump = 0x21`
	- ##### Description
		The player has used a spring.
- ##### `IsPhantomRush = 0x26`
	- ##### Description
		The player has Phantom Rush.
***
### `enum WorldFlags`
#### Description
An enum containing known world flags.
#### Members
- ##### `IsDead = 0x01`
	- ##### Description
		The player is dead.
- ##### `IsDamagedOrRepelled = 0x02`
	- ##### Description
		The player has taken damage or has been repelled by an enemy's shield.
- ##### `IsAutoRun = 0x0A`
	- ##### Description
		The player is in an auto run section.
- ##### `IsCyberSpace = 0x1D`
	- ##### Description
		The player is in Cyber Space.
- ##### `IsPowerBoost = 0x26`
	- ##### Description
		The player has Power Boost.
- ##### `IsHeightMapCollision = 0x31`
	- ##### Description
		The player is standing on collision pertaining to the height map.
- ##### `IsBattle = 0x3A`
	- ##### Description
		The player is in battle.
