# BlackboardBattle
Provides access to `app::player::BlackboardBattle` from Sonic Frontiers.
***
### `struct Data`
#### Description
A struct representation of `app::player::BlackboardBattle`.
#### Members
- ##### `BlackboardContent BlackboardContent`
	- ##### Description
		An instance of `app::player::BlackboardContent`, the base class for `app::player::BlackboardBattle`.
- ##### `float PhantomRushAmount`
	- ##### Description
		The value of the Phantom Rush gauge.
- ##### `float QuickCyloopAmount`
	- ##### Description
		The value of the Quick Cyloop gauge.
***
### `Data* Get()`
#### Description
Gets an instance of `app::player::BlackboardBattle`.
#### Return Value
A pointer to an instance of `app::player::BlackboardBattle`.
#### Example
```csharp
Code
//
    #lib "BlackboardBattle"
//
{
    var pBlackboardBattle = BlackboardBattle.Get();
}
```
