# BlackboardItem
Provides access to `app::player::BlackboardItem` from Sonic Frontiers.
***
### `struct Data`
#### Description
A struct representation of `app::player::BlackboardBattle`.
#### Members
- ##### `BlackboardContent BlackboardContent`
	- ##### Description
		An instance of `app::player::BlackboardContent`, the base class for `app::player::BlackboardItem`.
- ##### `int RingCapacity`
	- ##### Description
		The maximum amount of rings the player can hold.
- ##### `int RingCount`
	- ##### Description
		The current ring count for the player.
***
### `Data* Get()`
#### Description
Gets an instance of `app::player::BlackboardItem`.
#### Return Value
A pointer to an instance of `app::player::BlackboardItem`.
#### Example
```csharp
Code
//
    #lib "BlackboardItem"
//
{
    var pBlackboardItem = BlackboardItem.Get();
}
```
