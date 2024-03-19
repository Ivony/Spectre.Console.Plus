using System.Collections;
using System.Diagnostics;

using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public abstract class ContentContainer( params ContentNode[] children ) : ContentNode
{

  private readonly IList<ContentNode> _list = new List<ContentNode>( children );

  protected virtual void AppendChild( ContentNode child )
  {
    _list.Add( child );
  }


  public IEnumerable<ContentNode> Children => _list;



  /// <summary>
  /// 重写 Render 方法，调用所有子节点的 Render 方法
  /// </summary>
  /// <param name="context">渲染上下文</param>
  public override void Render( ContentRenderContext context )
  {
    foreach ( var child in Children )
      RenderChild( context, child );
  }

  protected virtual void RenderChild( ContentRenderContext context, ContentNode child )
  {
    child.Render( context );
  }
}