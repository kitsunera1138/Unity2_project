Shader "Custom/SurfaceShader2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // �⺻ �ؽ�ó
        _Curvature("Curvature", float) = 0.001  // ���
        _Color("Color", Color) = (1, 1, 1, 1)  // ���� �߰� (����Ʈ�� ���)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert addshadow
        uniform sampler2D _MainTex;
        uniform float _Curvature;
        uniform float4 _Color;  // ���� ���� �߰�

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
            half4 c = tex2D(_MainTex, IN.uv_MainTex);  // �ؽ�ó ����
            o.Albedo = c.rgb * _Color.rgb;  // �ؽ�ó ���� ���� ���ϱ�
            o.Alpha = c.a;
        }

        ENDCG        
    }
    FallBack "Mobile/Diffuse"
}
