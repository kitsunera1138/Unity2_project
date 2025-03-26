Shader "Custom/SurfaceShader2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // 기본 텍스처
        _Curvature("Curvature", float) = 0.001  // 곡률
        _Color("Color", Color) = (1, 1, 1, 1)  // 색상 추가 (디폴트는 흰색)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert addshadow
        uniform sampler2D _MainTex;
        uniform float _Curvature;
        uniform float4 _Color;  // 색상 변수 추가

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
            worldSpace.xyz -= _WorldSpaceCameraPos.xyz;
            worldSpace = float4(0.0f, (worldSpace.z * worldSpace.z) * -_Curvature, 0.0f, 0.0f);
    
            v.vertex += mul(unity_WorldToObject, worldSpace);
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            half4 c = tex2D(_MainTex, IN.uv_MainTex);  // 텍스처 색상
            o.Albedo = c.rgb * _Color.rgb;  // 텍스처 색상에 색상 곱하기
            o.Alpha = c.a;
        }

        ENDCG        
    }
    FallBack "Mobile/Diffuse"
}
