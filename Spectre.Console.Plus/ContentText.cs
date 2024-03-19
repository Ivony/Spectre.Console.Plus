using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public class ContentText( string text ) : ICascadableStyleContent
{


  private ContentText( CascadableStyle style, string text ) : this( text )
  {
    Style = style;
  }


  public string Text => text;

  protected readonly CascadableStyle Style = CascadableStyle.Empty;


  IRenderable ICascadableStyleContent.CascadeStyle( CascadableStyle style )
  {
    return new ContentText( Style << style, text );
  }

  public Measurement Measure( RenderOptions options, int maxWidth )
  {
    return new Measurement( 0, Math.Min( Text.Length, maxWidth ) );
  }

  public IEnumerable<Segment> Render( RenderOptions options, int maxWidth )
  {
    return [new Segment( Text, Style )];
  }

  public static implicit operator ContentText( string text ) => new ContentText( text );
  public static implicit operator ContentNode( ContentText text ) => new ContentNode( text );


  public override string ToString() => Text;

}