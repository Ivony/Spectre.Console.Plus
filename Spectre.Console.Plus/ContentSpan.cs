using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;
public class ContentSpan( CascadableStyle style, params ContentNode[] children ) : StyledContentContainer( style, children ), ICascadableStyleContent
{

  public IRenderable CascadeStyle( CascadableStyle style )
  {
    return new ContentSpan( Style >> style, children );

  }

  public static implicit operator ContentNode( ContentSpan span ) => new ContentNode( span );

  public static implicit operator ContentSpan( ValueTuple<CascadableStyle, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2 );
  public static implicit operator ContentSpan( ValueTuple<CascadableStyle, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3 );
  public static implicit operator ContentSpan( ValueTuple<CascadableStyle, ContentNode, ContentNode, ContentNode> styledContent ) => new ContentSpan( styledContent.Item1, styledContent.Item2, styledContent.Item3, styledContent.Item4 );


}
