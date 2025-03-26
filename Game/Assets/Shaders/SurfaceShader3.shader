Shader "Custom/SurfaceShader3"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // �⺻ �ؽ�ó
        _Curvature("Curvature", float) = 0.001  // ���
        _Color("Color", Color) = (1, 1, 1, 1)  // ����
        _Metallic ("Metallic", Range(0, 1)) = 0  // �ݼӼ�
        _Smoothness ("Smoothness", Range(0, 1)) = 0  // �Ų�����
        _NormalMap ("Normal Map", 2D) = "bump" {}  // ��� ��
        _Emission ("Emission", Color) = (0, 0, 0)  // �߱� ����
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard vertex:vert addshadow
        uniform sampler2D _MainTex;
        uniform float _Curvature;
        uniform float4 _Color;
        uniform float _Metallic;
        uniform float _Smoothness;
        uniform sampler2D _NormalMap;
        uniform float4 _Emission;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalMap;
        };

        void vert(inout appdata_full v)
        {
            float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
            worldSpace.xyz -= _WorldSpaceCameraPos.xyz;
            worldSpace = float4(0.0f, (worldSpace.z * worldSpace.z) * -_Curvature, 0.0f, 0.0f);
    
            v.vertex += mul(unity_WorldToObject, worldSpace);
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // �ؽ�ó ����
            half4 texColor = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = texColor.rgb * _Color.rgb;
            o.Alpha = texColor.a;

            // �ݼӼ� (Metallic)�� �Ų����� (Smoothness)
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;

            // ��� �� ����
            half4 normalTex = tex2D(_NormalMap, IN.uv_MainTex);
            o.Normal = UnpackNormal(normalTex);

            // �߱� ���� (Emission)
            o.Emission = _Emission.rgb;
        }

        ENDCG
    }
    FallBack "Mobile/Diffuse"
}
