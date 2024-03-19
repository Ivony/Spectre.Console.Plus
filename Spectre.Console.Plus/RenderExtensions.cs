using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectre.Console.Plus;
public static class RenderExtensions
{

  public static void Render( this IAnsiConsole console, ContentNode node )
  {
    node.Render( new ContentRenderContext( console, new ContentRenderPosition() ) );
  }

}
