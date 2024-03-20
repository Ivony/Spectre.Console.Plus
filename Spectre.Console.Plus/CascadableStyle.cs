namespace Spectre.Console.Plus;

public sealed record CascadableStyle( Color? Foreground = null, Color? Background = null, Decoration? Decoration = null )
{

  public CascadableStyle Merge( CascadableStyle other, bool throwIfConflict = false )
  {

    Exception Conflict()
    {
      return new InvalidOperationException( "style conflict, merge failed." );
    }


    if ( throwIfConflict )
    {
      if ( other.Foreground != null && this.Foreground != null )
        throw Conflict();

      if ( other.Background != null && this.Background != null )
        throw Conflict();

      if ( other.Decoration != null && this.Decoration != null )
        throw Conflict();
    }


    return new CascadableStyle(
      other.Foreground ?? Foreground,
      other.Background ?? Background,
      other.Decoration ?? Decoration
    );
  }


  public static readonly CascadableStyle Empty = new CascadableStyle();



  public static CascadableStyle operator <<( CascadableStyle basement, CascadableStyle overwrite ) => basement.Merge( overwrite );
  public static CascadableStyle operator >>( CascadableStyle overwrite, CascadableStyle basement ) => basement.Merge( overwrite );
  public static CascadableStyle operator +( CascadableStyle basement, CascadableStyle overwrite ) => basement.Merge( overwrite, true );


  public static implicit operator CascadableStyle( Style style ) => new CascadableStyle( style.Foreground, style.Background, style.Decoration );
  public static implicit operator Style( CascadableStyle style ) => new Style( style.Foreground, style.Background, style.Decoration );


  public static implicit operator CascadableStyle( Color color ) => new CascadableStyle( color );
  public static implicit operator CascadableStyle( ValueTuple<Color, Color> style ) => new CascadableStyle( style.Item1, style.Item2 );
  public static implicit operator CascadableStyle( ValueTuple<Color, Color, Decoration> style ) => new CascadableStyle( style.Item1, style.Item2, style.Item3 );
  public static implicit operator CascadableStyle( ValueTuple<Color, Decoration> style ) => new CascadableStyle( style.Item1, null, style.Item2 );
  public static implicit operator CascadableStyle( Decoration decoration ) => new CascadableStyle( null, null, decoration );

}