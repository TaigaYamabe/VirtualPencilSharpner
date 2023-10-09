Shader "Custom/Cutout" {
    Properties{
        _Color("Color", Color) = (0,0,0,0)
    }

        SubShader{
            Tags {"Queue" = "Geometry-1"}

            Pass{
                Zwrite On
                ColorMask 0
            }
    }
}