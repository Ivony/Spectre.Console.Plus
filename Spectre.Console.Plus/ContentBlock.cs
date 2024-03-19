using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public class ContentBlock( CascadableStyle style, params ContentNode[] children ) : StyledContentContainer( style, children ), ICascadableStyleContent
{
  public IRenderable CascadeStyle( CascadableStyle style )
  {
    return new ContentBlock( Style >> style, children );

  }

  public override IEnumerable<Segment> Render( RenderOptions options, int maxWidth )
  {
    return base.Render( options, maxWidth ).Concat( [Segment.LineBreak] );
  }


  public static implicit operator ContentNode( ContentBlock block ) => new ContentNode( block );

}
