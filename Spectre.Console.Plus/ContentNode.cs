using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

/// <summary>
/// ContentNode is the base type of all content control.
/// </summary>
public sealed record ContentNode( IRenderable Renderable )
{
  public static implicit operator ContentNode( string text ) => new ContentText( text );

  public static implicit operator ContentNode( Renderable renderable ) => new ContentNode( (IRenderable) renderable );


}
