namespace Spectre.Console.Plus;

public sealed record CascadableStyle( Color? Foreground = null, Color? Background = null )
{

  public CascadableStyle Merge( CascadableStyle other )
  {
    return new CascadableStyle(
      other.Foreground ?? Foreground,
      other.Background ?? Background
    );
  }


  public static readonly CascadableStyle Empty = new CascadableStyle();



  public static CascadableStyle operator <<( CascadableStyle basement, CascadableStyle overwrite ) => basement.Merge( overwrite );
  public static CascadableStyle operator >>( CascadableStyle overwrite, CascadableStyle basement ) => basement.Merge( overwrite );


  public static implicit operator CascadableStyle( Style style ) => new CascadableStyle( style.Foreground, style.Background );
  public static implicit operator Style( CascadableStyle style ) => new Style( style.Foreground, style.Background );




  public static implicit operator CascadableStyle( Color color ) => new CascadableStyle( color );
  public static implicit operator CascadableStyle( ValueTuple<Color, Color> style ) => new CascadableStyle( style.Item1, style.Item2 );

}