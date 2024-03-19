namespace Spectre.Console.Plus;

public static class Contents
{
  public static ContentText Text( string text ) => new ContentText( text );

  public static ContentBlock Block( params ContentNode[] children ) => new ContentBlock( CascadableStyle.Empty, children );

  public static ContentBlock Block( CascadableStyle style, params ContentNode[] children ) => new ContentBlock( style, children );

  public static ContentSpan Span( params ContentNode[] children ) => new ContentSpan( CascadableStyle.Empty, children );

  public static ContentSpan Span( CascadableStyle style, params ContentNode[] children ) => new ContentSpan( style, children );



  public static CascadableStyle AsBackground( this Color color ) => new CascadableStyle( null, color );

}
