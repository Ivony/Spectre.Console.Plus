using Spectre.Console;

using static Spectre.Console.Plus.Contents;

IAnsiConsole console = AnsiConsole.Console;

console.Write( Block( "Hello", " ", (Color.Aqua, "World", (Color.Red, "!")) ) );