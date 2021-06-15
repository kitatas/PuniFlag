Shader "Custom/BackgroundShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    CGINCLUDE
    #include "UnityCG.cginc"

    float2 rotate(float2 ist)
    {
        float angle = _Time.y * 1.5;
        float2x2 rotate = float2x2(cos(angle), -sin(angle), sin(angle), cos(angle));
        float scale = 0.5;
        float2 pivot_uv = float2(0.5, 0.5);
        float2 r = (ist - pivot_uv) * (1 / scale);
        return mul(rotate, r) + pivot_uv;
    }

    float4 frag(v2f_img i) : SV_Target
    {
        float n = 11;
        float2 ist = floor(i.uv * n) / n;
        float2 rot = rotate(ist);

        return lerp(
            float4(0.90, 0.70, 0.40, 1.0),
            float4(0.70, 0.50, 0.40, 1.0),
            float4(rot * 0.8, 1, 1)
        );
    }

    ENDCG

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    }
}