using UnityEngine;
using UnityEngine.UI;

public static class ImageExtentions
{
    public static void SetTransparency(this Image thisColor, float value) =>
        thisColor.color = new Color(thisColor.color.r, thisColor.color.g, thisColor.color.b, value);

    public static float GetTransparency(this Image thisColor) => thisColor.color.a;

    public static void SetTransparency(this SpriteRenderer thisColor, float value) =>
        thisColor.color = new Color(thisColor.color.r, thisColor.color.g, thisColor.color.b, value);

    public static float GetTransparency(this SpriteRenderer thisColor) => thisColor.color.a;
}
