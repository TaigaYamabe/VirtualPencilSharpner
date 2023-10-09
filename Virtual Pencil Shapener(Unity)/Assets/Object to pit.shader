Shader "Custom/ObjectToPit" {
    Properties {
        _BaseColor("Base Color",Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white"
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Stencil {
            Ref 1
            Comp NotEqual
            Pass keep
        }

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 3.0
        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };
        fixed4 _BaseColor;
        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = _BaseColor.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}