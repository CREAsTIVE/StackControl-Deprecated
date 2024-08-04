StackControl
=
Stack control is a stack-oriented language where you can move youre cursor on the stack however you want.

Cursor
-
You have a cursor on the stack. This works similarly to a normal cursor when typing text. *Current element* is the element that is in front of the cursor. When you push an element, it is added after the current element and the cursor moves 1 element to the right. When you delete an element, the current element is deleted.
Top/head of the stack is cursor, farther - overhead

You can move cursor on the stack by using `←` (`mvl`) and `→` (`mvr`)

Commands
-
The source code consists only of commands. Commands are executed in turn from left to right. Each command affects the stack in some way
*For example: command `⦽` (`union`) gets current value as array and unpacks it (places all values on top of the stack)*

**All constants are also commands that push some value onto the stack**
`15` gonna be parsed as command `StackPusher(SCNumber(15))` (`StackPusher` command pushes any `SCObject` to the top of the stack)

almost every command has word association with it. You didn't need to use a lot of symbols, you can just use names/aliases of commands.
Try to execute this example from [code-golf stack overflow answer](https://codegolf.stackexchange.com/a/274670/120155) one with "to symbols" option enabled:
```
R split unpack 0 mvl : alen (aloopr quadrodub = (1mvl)?)repeat mvr("yes"W)("no"W)⁇
```

You can see all commands and their aliases [there](https://github.com/CREAsTIVE/StackControl/blob/v0.1-alpha/StackControl/Environment.cs) (i know its ugly, i gonna fix it soon and make document with all commands and their description)


Arrays
-
You can put token `[` to the stack, and then execute command `]`. This command gonna take all values from the top to the next `[` and make list of them.
For example:
```
[[1 2 3 "abc"] "yep"]
```

Strings are just array of chars

Functions
-
Instead of execution function right away you can push **command container** on top of the stack by using `#` or `(` with `)`
`#+` gonna be parsed as `StackPusher(CommandContainer(Sum()))`
You can execute any function by `!`
For example:
```
1 2 #+ !
```
Gonna push `1` and `2` on top of the stack, then push command `+` and only then execute it with `!`
That means you can also make command container for a stack pushed of command container like that: `##+`. If it gonna be executed command container with `+` gonna be pushed on the stack

You can also use `()` to make multi-command function. `(a b c)` just gonna be converted onto `[#a #b #c]`
If you trying to execute array it gonna try to execute every single element from it.

Simple example:
```
[1 2 3] (2 *) ∵
```
Stack:
```
[2 4 6]
```

Explanation:

`∵` (`each`) firstly pops executable from top of the stack and then modifies array from the top of the stack
Then it does that for the every value:
* pushes current value on to the stack
* execute callable poped value
* pops value from the top of the stack
* change current value to the new popped value

For this example we add another value on to the stack and multiply 2 top values on the stack.

Also, every object is executable, and if it isn't overrided by deafult object gonna compare itself with another object on top of the stack
So you can do something like this:
```
[1 2 3 4 3 2 1] 3 ∵
```
Stack:
```
[0 0 1 0 1 0 0]
```