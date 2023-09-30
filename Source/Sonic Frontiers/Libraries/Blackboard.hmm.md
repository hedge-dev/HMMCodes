# Blackboard
Provides access to `app::player::Blackboard` from Sonic Frontiers.
***
### `struct Data`
#### Description
A struct representation of `app::player::Blackboard`.
#### Members
- ##### `MoveArray<Memory.Pointer<BlackboardContent>> BlackboardContents`
	- ##### Description
		An array of pointers to `app::player::BlackboardContent` instances.
***
### `struct BlackboardContent`
#### Description
A struct representation of `app::player::BlackboardContent`.
#### Members
- ##### `VFUNCTION_PTR(Data, 1, uint, GetNameHash)`
	- ##### Description
		Gets the string hash pertaining to the name of this `app::player::BlackboardContent` type.
	- ##### Return Value
		The string hash pertaining to the name of this `app::player::BlackboardContent` type.
	- ##### Example
		```csharp
		Code
		//
		    #lib "Blackboard"
		    #lib "BlackboardStatus"
		//
		{
		    var pBlackboardStatus = Blackboard.GetPlayerBlackboardContent<BlackboardStatus.Data>(pBlackboard);
		    
		    // Prints the name hash to the console.
		    Console.WriteLine(((uint)pBlackboardStatus->GetNameHash().DynamicInvoke()).ToString("X"));
		}
		```
***
### `long GetBlackboardContent(Data* in_pBlackboard, string in_name)`
#### Description
Gets an instance of `app::player::BlackboardContent` obtained by the input `app::player::Blackboard` instance by name.
#### Arguments
- `in_pBlackboard` - An instance of `app::player::Blackboard`.
- `in_name` - The name of the instance of `app::player::BlackboardContent` to find.
#### Return Value
A pointer to an instance of `app::player::BlackboardContent`.
#### Example
```csharp
Code
//
    #lib "Blackboard"
//
{
    var pBlackboard = Blackboard.GetPlayerBlackboard();
    var pBlackboardStatus = Blackboard.GetBlackboardContent(pBlackboard, "BlackboardStatus");
}
```
***
### `T* GetBlackboardContent<T>(Data* in_pBlackboard) where T : unmanaged`
#### Description
Gets an instance of `app::player::BlackboardContent` obtained by the input `app::player::Blackboard` instance.
#### Arguments
- `in_pBlackboard` - An instance of `app::player::Blackboard`.
#### Return Value
A pointer to an instance of `app::player::BlackboardContent`.
#### Example
```csharp
Code
//
    #lib "Blackboard"
    #lib "BlackboardStatus"
//
{
    var pBlackboard = Blackboard.GetPlayerBlackboard();
    var pBlackboardStatus = Blackboard.GetBlackboardContent<BlackboardStatus.Data>(pBlackboard);
}
```
***
### `Data* GetPlayerBlackboard()`
#### Description
Gets an instance of `app::player::Blackboard` obtained by the current player.
#### Return Value
A pointer to an instance of `app::player::Blackboard`.
#### Example
```csharp
Code
//
    #lib "Blackboard"
//
{
    var pBlackboard = Blackboard.GetPlayerBlackboard();
}
```
***
### `long GetPlayerBlackboardContent(string in_name)`
#### Description
Gets an instance of `app::player::BlackboardContent` obtained by the current player by name.
#### Arguments
- `in_name` - The name of the instance of `app::player::BlackboardContent` to find.
#### Return Value
A pointer to an instance of `app::player::BlackboardContent`.
#### Example
```csharp
Code
//
    #lib "Blackboard"
//
{
    var pBlackboardStatus = Blackboard.GetPlayerBlackboardContent("BlackboardStatus");
}
```
***
### `T* GetPlayerBlackboardContent<T>() where T : unmanaged`
#### Description
Gets an instance of `app::player::BlackboardContent` obtained by the current player.
#### Return Value
A pointer to an instance of `app::player::BlackboardContent`.
#### Example
```csharp
Code
//
    #lib "Blackboard"
    #lib "BlackboardStatus"
//
{
    var pBlackboardStatus = Blackboard.GetPlayerBlackboardContent<BlackboardStatus.Data>();
}
```
