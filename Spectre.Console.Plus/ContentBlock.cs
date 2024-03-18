using Spectre.Console.Rendering;

namespace Spectre.Console.Plus
{
  public class ContentBlock : ContentContainer
  {

    public override IEnumerable<Segment> Render( RenderOptions options, int maxWidth )
    {
      return base.Render( options, maxWidth ).Concat( [Segment.LineBreak] );
    }
  }
}
