using Spectre.Console;
using Spectre.Console.Plus;

using static Spectre.Console.Plus.Contents;

IAnsiConsole console = AnsiConsole.Console;

console.Render( Block( Color.DarkSeaGreen.AsBackground(), "Hello", " ", (Color.Aqua, "World", (Color.Red, "!")) ) );