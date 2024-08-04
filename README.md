StackControl
=
StackControl is an esoteric language that was created for fun. The main feature is that now there is a cursor on the stack that you can move as you like

That language **didn't** desined for code-golf, the main purpose - look cool with a lot of beautiful symbols :D

Cursor
-
You have a cursor on the stack. 
This works similarly to a normal cursor when typing text. 

You can move cursor on the stack by using `←` (`mvl`) and `→` (`mvr`)

Commands
-
The source code consists only of commands. Commands are executed in turn from left to right. Each command affects the stack in some way.

**All constants are also commands that push some value onto the stack**

*For example:* 
```
"abc" 15 20
```
*will be parsed as:*
```
[SCCommands.StackPusher(SCString("abc")), SCCommands.StackPusher(SCNumber(15)), SCCommands.StackPusher(SCNumber(20))]
```

Almost every command has word association with it. You didn't need to use a lot of symbols, you can just use names/aliases of commands.

Try to execute this example from [code-golf stack overflow answer](https://codegolf.stackexchange.com/a/274670/120155) with `to symbols` option enabled:
```
R split unpack 0 mvl : alen (aloopr qdup = (1mvl)?)repeat mvr("yes"W)("no"W)⁇
```

You can see all default commands and their aliases [there](https://github.com/CREAsTIVE/StackControl/blob/master/StackControl/Environment.cs)


Arrays
-
You can put token `[` to the stack, and then execute command `]`. 
This command gonna take all values from the top to the next `[` and make list of them:

```
[[1 2 3 "abc"] "yep"]
```

*Note: SCString just array of SCChar*

Functions
-
Instead of execution function right away you can push **command container** on top of the stack by using `#` or `(` with `)`.

`#+` gonna be parsed as 
```
SCCommands.StackPusher(SCObjects.CommandContainer(SCCommands.Sum()))
```
and when executed will place command container with sum command on top of the stack

You can execute any function by `!`:

```
1 2 #+ !

OUTPUT: 3
```
This code:
* pushes 1 on top of the stack
* pushes 2 on top of the stack
* pushes `◉+`: command container with command `+` on top of the stack
* execute command container on the stack, `+` command will pick up 2 values from the stack and store the result

You can also place a container of command, that places container of command like that:
```
1 2 ##+ ! !
```
In this scenario is places `◉#+` on top of the stack. When executed with first `!` it will place `◉+` on the stack. Second execution will execute `+`

-----
If you try to execute array everything inside it will be executed instead. So u can make functions like that:
```
2 3			- values on the stack
[#+ #2 #*]	- function
!			- will sum 2 and 3, then pushes 2 on top of the stack and multiply it with 5
```
To define functions easier you can use `(` and `)`:
```
(+2*)		- simpler
```

Some examples:

*Note: `∵` (each) will apply function for each element from array*
```
CODE:
[1 2 3] (2 *) ∵		

OUTPUT:
[2 4 6]
```
```
CODE:
3 ("b" 2 ("a") ⟲) ⟲

OUTPUT:
"b" "a" "a" "b" "a" "a" "b" "a" "a"
```

*Note: every object is executable, and if it isn't overrided by default it tries to compare itself with value on the stack:*
```
CODE:
[1 2 3 4 3 2 1] 3 ∵

OUTPUT:
[0 0 1 0 1 0 0]
```