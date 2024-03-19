using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public class ContentText( string text ) : ContentNode, ICascadableStyleContent
{


  private ContentText( CascadableStyle style, string text ) : this( text )
  {
    Style = style;
  }


  public string Text => text;

  protected readonly CascadableStyle Style = CascadableStyle.Empty;


  ContentNode ICascadableStyleContent.CascadeStyle( CascadableStyle style )
  {
    return new ContentText( Style << style, text );
  }

  public override void Render( ContentRenderContext context )
  {
    context.Console.Write( text, Style );
  }

  public static implicit operator ContentText( string text ) => new ContentText( text );


  public override string ToString() => Text;

}