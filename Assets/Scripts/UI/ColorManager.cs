using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;

    protected override void Awake()
    {
        color1 = new Color(0.733f, 0.871f, 0.839f, 1);
        color2 = new Color(0.380f, 0.753f, 0.749f, 1);
        color3 = new Color(1, 0.714f, 0.725f, 1);
        //color4 = new Color();
    }

}
