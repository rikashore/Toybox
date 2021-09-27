# Toybox
A simple esolang made to learn Sprache

## Usage
Toybox is pretty simple and as such theres only a few commands

### Printing

`writel` prints the statement ahead of it and places a newline at the end.

```
writel 11
writel "toybox"
```

`write` prints the statement and will not place a newline at the end.

```
write "hello"
write " world!\n"
```

### Variables
variables are created through the `in .. place` syntax.

```
in name place "shift"
in myNum place 11
```

### Toyboxes
Toyboxes are a stack based collection. They are created by opening one

```
open toybox tb1
```

Toyboxes can be pushed to

```
into tb1 push "string1"
into tb1 push 14
into tb1 push name
```

And can be popped from

```
pop from tb1
```

### Looping
You can also loop through toyboxes and perform an action on them, currently this means either using `write` or `writel`

```
loop through tb1 and writel
loop through tb1 and write
```
