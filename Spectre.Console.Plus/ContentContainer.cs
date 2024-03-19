using System.Collections;

using Spectre.Console.Rendering;

namespace Spectre.Console.Plus
{
  public abstract class ContentContainer : ICascadableStyleContent
  {

    private IList<IRenderable> _list = new List<IRenderable>();

    protected virtual void AppendChild( IRenderable child )
    {
      _list.Add( child );
    }


    public IEnumerable<IRenderable> Children => _list;

    public virtual Measurement Measure( RenderOptions options, int maxWidth )
    {
      var measures = Children.Select( item => item.Measure( options, maxWidth ) );
      return new Measurement( measures.Max( item => item.Min ), measures.Max( item => item.Max ) );
    }

    public virtual IEnumerable<Segment> Render( RenderOptions options, int maxWidth ) => Render( options, maxWidth, null );

    protected virtual IEnumerable<Segment> Render( RenderOptions options, int maxWidth, Style? style )
    {
      var context = new SegmentRenderContext( options, maxWidth, style, new SegmentRenderPosition() );

      foreach (var segment in Children.SelectMany( item => item.Render( options, maxWidth ) ))
      {
        var result = RenderSegment( context, segment );
        context = context with { Position = result.Position };

        foreach (var item in result)
          yield return item;
      }
    }

    public virtual IRenderable CascadeStyle( Style style )
    {
      return new StyledContentContainer( style, this );
    }


    protected virtual SegmentRenderResult RenderSegment( SegmentRenderContext context, Segment segment )
    {
      var position = context.Position;

      if (segment.IsControlCode == false)
        position = position.Advance( segment.Text.Length, context.MaxWidth );

      if (segment.IsLineBreak)
        position = position.NewLine();

      return new SegmentRenderResult( position, segment );
    }

    private class StyledContentContainer( Style style, ContentContainer container ) : IRenderable
    {
      public Measurement Measure( RenderOptions options, int maxWidth ) => container.Measure( options, maxWidth );

      public IEnumerable<Segment> Render( RenderOptions options, int maxWidth ) => container.Render( options, maxWidth, style );
    }



  }



  public record SegmentRenderContext( RenderOptions Options, int MaxWidth, Style? Style, SegmentRenderPosition Position )
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
      while (chars > maxWidth)
      {
        chars -= maxWidth;
        line++;
      }

      return new SegmentRenderPosition( line, chars, offset );
    }
  }
}
