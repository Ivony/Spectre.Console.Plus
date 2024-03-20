using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

/// <summary>
/// ContentNode is the base type of all content control.
/// </summary>
public abstract class ContentNode
{

  public abstract void Render( ContentRenderContext context );


  public static implicit operator ContentNode( string text ) => new ContentText( text );


  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3, styledContent.Item4 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3, styledContent.Item4, styledContent.Item5 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode, ContentNode, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3, styledContent.Item4, styledContent.Item5, styledContent.Item6 );
  public static implicit operator ContentNode( ValueTuple<CascadableStyle, ContentNode, ContentNode, ContentNode, ContentNode, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3, styledContent.Item4, styledContent.Item5, styledContent.Item6, styledContent.Item7 );


}
