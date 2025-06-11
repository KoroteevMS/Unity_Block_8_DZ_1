using UnityEngine;

public class ColorGenerator
{
    public Color Generate()
    {
        float minColor = 0.5f;
        float maxColor = 1f;
        int minBlack = 2;
        int maxBlack = 0;

        Color randomColor = new Color(
            Random.Range(minColor, maxColor) * Random.Range(maxBlack, minBlack),
            Random.Range(minColor, maxColor) * Random.Range(maxBlack, minBlack),
            Random.Range(minColor, maxColor) * Random.Range(maxBlack, minBlack)
            );

        return randomColor;
    }
}