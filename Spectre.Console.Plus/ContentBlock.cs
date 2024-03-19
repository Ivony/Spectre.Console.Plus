using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public class ContentBlock( CascadableStyle style, params ContentNode[] children ) : StyledContentContainer( style, children ), ICascadableStyleContent
{
  public ContentNode CascadeStyle( CascadableStyle style )
  {
    return new ContentBlock( Style >> style, children );
  }

  public override void Render( ContentRenderContext context )
  {
    base.Render( context );

    context.Console.WriteLine();
  }



}
