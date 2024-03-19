using System.Collections;
using System.Diagnostics;

using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

public abstract class ContentContainer( params ContentNode[] children ) : IRenderable
{

  private readonly IList<ContentNode> _list = new List<ContentNode>( children );

  protected virtual void AppendChild( ContentNode child )
  {
    _list.Add( child );
  }


  public IEnumerable<IRenderable> Children => _list.Select( node => node.Renderable );

  public virtual Measurement Measure( RenderOptions options, int maxWidth )
  {
    Debug.WriteLine( $"Measure: {maxWidth}" );

    var measures = Children.Select( item => item.Measure( options, maxWidth ) );

#if DEBUG
    foreach ( var item in measures )
      Debug.WriteLine( $"  Item: {item.Min}, {item.Max}" );
#endif

    var result = new Measurement( measures.Max( item => item.Min ), measures.Max( item => item.Max ) );
    Debug.WriteLine( $"  Result: {result.Min}, {result.Max}" );
    return result;
  }

  public virtual IEnumerable<Segment> Render( RenderOptions options, int maxWidth )
  {
    var context = new SegmentRenderContext( options, maxWidth, new SegmentRenderPosition() );

    foreach ( var segment in Children.SelectMany<IRenderable, Segment>( item => RenderChild( context, item ) ) )
    {
      var result = RenderSegment( context, segment );
      context = context with { Position = result.Position };

      foreach ( var item in result )
        yield return item;
    }
  }

  protected virtual IEnumerable<Segment> RenderChild( SegmentRenderContext context, IRenderable child ) => child.Render( context.Options, context.MaxWidth );

  protected virtual SegmentRenderResult RenderSegment( SegmentRenderContext context, Segment segment )
  {
    var position = context.Position;

    if ( segment.IsControlCode == false )
      position = position.Advance( segment.Text.Length, context.MaxWidth );

    if ( segment.IsLineBreak )
      position = position.NewLine();

    return new SegmentRenderResult( position, segment );
  }




}



public record SegmentRenderContext( RenderOptions Options, int MaxWidth, SegmentRenderPosition Position )
{

}


/// <summary>
/// 获取 Segment 渲染结果
/// </summary>
/// <param name="Position"></param>
/// <param name="Segments"></param>
public readonly record struct SegmentRenderResult( SegmentRenderPosition Position, params Segment[] Segments ) : IEnumerable<Segment>
{
  public IEnumerator<Segment> GetEnumerator()
  {
    return ((IEnumerable<Segment>) Segments).GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return Segments.GetEnumerator();
  }
}




/// <summary>
/// 指示渲染的位置
/// </summary>
/// <param name="Line">当前渲染的行</param>
/// <param name="Chars">当前渲染的字符数</param>
/// <param name="Offset">当前渲染的总偏移量</param>
public readonly record struct SegmentRenderPosition( int Line, int Chars, int Offset )
{
  public SegmentRenderPosition NewLine()
  {
    return new SegmentRenderPosition( Line + 1, 0, Offset );
  }

  public SegmentRenderPosition Advance( int length, int maxWidth )
  {
    var line = Line;
    var chars = Chars + length;
    var offset = Offset + length;
    while ( chars > maxWidth )
    {
      chars -= maxWidth;
      line++;
    }

    return new SegmentRenderPosition( line, chars, offset );
  }
}
