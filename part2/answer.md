## Good points about this code:

I like the usage of `is` in a code. It is a maintainable and quick way to identify a type.
The `as` coupled with the null coalescing operator `?` is a good practice to cast and treat null in recent C#.

## Bad points about this code:

The usage of type guessing and casting may not be a good practice in this case.
It makes the whole code structure heavy. This practice also makes the code live without any solid architecture principle.
Because of those points, the maintenability of the code is compromised.

An alternative would be to make every `Message` (A,B,C) `IMessage` for example. The interface methods like `MyCustomMethod` will be implemented differently according to the business.
Also, the code of the `SomeAdditionalMethodOnB` can be incorporated in a private method in the implementation of MessageB, and called by MyCustomMethod.