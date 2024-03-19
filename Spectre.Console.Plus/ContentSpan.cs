using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;
public class ContentSpan( CascadableStyle style, params ContentNode[] children ) : StyledContentContainer( style, children ), ICascadableStyleContent
{

  public IRenderable CascadeStyle( CascadableStyle style )
  {
    return new ContentSpan( Style >> style, children );

  }

  public static implicit operator ContentNode( ContentSpan span ) => new ContentNode( span );


}
