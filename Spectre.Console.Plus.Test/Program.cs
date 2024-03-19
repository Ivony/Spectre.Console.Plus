using Spectre.Console;

using static Spectre.Console.Plus.Contents;

IAnsiConsole console = AnsiConsole.Console;

console.Write( Block( "Hello", " ", Span( Color.Aqua, "World" ), Span( Color.Red, "!" ) ) );