using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Color[] destroyableBrickColors = new Color[]
    {
        new Color(59,177,219,86),
        new Color(205,103,219,86),
        new Color(81,182,219,86),
        new Color(219,142,59,86),
        new Color(146,219,70,86)
    };
    public static Color[] enemyBrickColors = new Color[]
    {
        new Color(156,22,12,61),
        new Color(92,13,7,36),
        new Color(219,31,18,86),
        new Color(232,33,19,91),
        new Color(194,27,16,76)
    };

    public static int SortRandomArrayIndex(int maxInclusive)
    {
        return Random.Range(0, maxInclusive);
    }

    public static Color SortRandomColorFromColors(Color[] colors)
    {
        return colors[SortRandomArrayIndex(colors.Length - 1)];
    }
}
