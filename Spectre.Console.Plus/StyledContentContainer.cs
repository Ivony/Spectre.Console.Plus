namespace Spectre.Console.Plus;
public abstract class StyledContentContainer( CascadableStyle style, params ContentNode[] children ) : ContentContainer( children )
{


  public CascadableStyle Style => style;

  protected override void RenderChild( ContentRenderContext context, ContentNode child )
  {
    if ( child is ICascadableStyleContent cascadable )
      child = cascadable.CascadeStyle( style );

    base.RenderChild( context, child );
  }

}
