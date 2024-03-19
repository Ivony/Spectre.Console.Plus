using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public record ContentText( string Text, Style? Style ) : ICascadableStyleContent
{

  IRenderable ICascadableStyleContent.CascadeStyle( Style style )
  {
    if ( Style == null )
      return new ContentText( Text, style );

    else
      return this;
  }

  Measurement IRenderable.Measure( RenderOptions options, int maxWidth )
  {
    return new Measurement( 0, Math.Min( Text.Length, maxWidth ) );
  }

  IEnumerable<Segment> IRenderable.Render( RenderOptions options, int maxWidth )
  {
    return [new Segment( Text, Style ?? Style.Plain )];
  }
}