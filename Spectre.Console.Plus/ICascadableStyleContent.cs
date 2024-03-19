using Spectre.Console.Rendering;

namespace Spectre.Console.Plus;

/// <summary>
/// 定义可继承样式的内容对象
/// </summary>
public interface ICascadableStyleContent
{

  /// <summary>
  /// 继承样式
  /// </summary>
  /// <param name="style">要继承的样式</param>
  /// <returns>继承样式后的可渲染对象</returns>
  ContentNode CascadeStyle( CascadableStyle style );
}