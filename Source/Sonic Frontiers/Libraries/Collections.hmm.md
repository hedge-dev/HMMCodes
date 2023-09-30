# Collections
Provides extended collection types.
***
### `struct MoveArray<T> where T : unmanaged`
#### Description
A struct representation of `csl::ut::MoveArray<T>`.
***
### `class StackList<T> : List<T>`
#### Description
A custom `System.Collections.Generic.List<T>` where items are added and retrieved like a stack.
***
### `void Add(T in_item)`
#### Description
Adds an item to the top of the stack.
#### Arguments
- `in_item` - The item to add.
***
### `T GetItemAt(int in_index)`
#### Description
Gets an item from any index in the stack.
#### Arguments
- `in_index` - The index to get the item from in the stack.
#### Return Value
The item in the stack at the requested index.
***
### `void Push(T in_item)`
#### Description
Adds an item to the top of the stack.
#### Arguments
- `in_item` - The item to add.
***
### `T Pop()`
#### Description
Gets an item from the top of the stack and removes it.
#### Return Value
The item at the top of the stack.
***
### `T Peek()`
#### Description
Gets the item at the top of the stack.
#### Return Value
The item at the top of the stack.
