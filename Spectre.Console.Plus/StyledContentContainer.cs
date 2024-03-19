using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;
public abstract class StyledContentContainer( CascadableStyle style, params ContentNode[] children ) : ContentContainer( children )
{


  public CascadableStyle Style => style;

  protected override IEnumerable<Segment> RenderChild( SegmentRenderContext context, IRenderable child )
  {
    if ( child is ICascadableStyleContent cascadable )
      child = cascadable.CascadeStyle( style );

    return base.RenderChild( context, child );
  }

}
