using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;


/// <summary>
/// 内容渲染上下文
/// </summary>
/// <param name="Console">用于输出的控制台对象</param>
/// <param name="Position">当前渲染的位置信息</param>
public record ContentRenderContext( IAnsiConsole Console, ContentRenderPosition Position )
{
  /// <param name="Position">当前渲染的位置信息</param>
  ContentRenderPosition Position { get; set; } = Position;
}

/// <summary>
/// 指示渲染的位置
/// </summary>
/// <param name="Line">当前渲染的行</param>
/// <param name="Chars">当前渲染的字符数</param>
/// <param name="Offset">当前渲染的总偏移量</param>
public readonly record struct ContentRenderPosition( int Line, int Chars, int Offset )
{
  public ContentRenderPosition NewLine()
  {
    return new ContentRenderPosition( Line + 1, 0, Offset );
  }

  public ContentRenderPosition Advance( int length, int maxWidth )
  {
    var line = Line;
    var chars = Chars + length;
    var offset = Offset + length;
    while ( chars > maxWidth )
    {
      chars -= maxWidth;
      line++;
    }

    return new ContentRenderPosition( line, chars, offset );
  }
}
