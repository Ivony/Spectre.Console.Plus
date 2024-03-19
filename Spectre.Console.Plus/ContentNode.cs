﻿using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

/// <summary>
/// ContentNode is the base type of all content control.
/// </summary>
public sealed record ContentNode( IRenderable Renderable )
{
  public static implicit operator ContentNode( string text ) => new ContentText( text );

  public static implicit operator ContentNode( Renderable renderable ) => new ContentNode( (IRenderable) renderable );


  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3, styledContent.Item4 );


}
