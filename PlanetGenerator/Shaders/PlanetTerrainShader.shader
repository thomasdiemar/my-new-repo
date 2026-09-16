// Unity Shader for Planet Terrain Rendering
Shader "Custom/PlanetTerrainShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _SpecularIntensity ("Specular Intensity", Range(0,1)) = 0.5
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _AmbientColor ("Ambient Color", Color) = (0.2, 0.2, 0.2, 1)
        _SunColor ("Sun Color", Color) = (1, 1, 1, 1)
        _SunDirection ("Sun Direction", Vector) = (0, 1, 0, 0)
        _AtmosphereThickness ("Atmosphere Thickness", Range(0, 1)) = 0.5
        _AtmosphereColor ("Atmosphere Color", Color) = (0.3, 0.6, 1.0, 1)
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "IgnoreProjector"="True" "LightMode"="ForwardBase" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
                float3 viewDir : TEXCOORD3;
                float3 lightDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            
            sampler2D _MainTex;
            sampler2D _BumpMap;
            float _SpecularIntensity;
            float _Glossiness;
            float4 _AmbientColor;
            float4 _SunColor;
            float4 _SunDirection;
            float _AtmosphereThickness;
            float4 _AtmosphereColor;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldPos));
                o.lightDir = normalize(_SunDirection.xyz);
                
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // Sample base texture and normal map
                fixed4 texColor = tex2D(_MainTex, i.uv);
                fixed4 bump = tex2D(_BumpMap, i.uv);
                
                // Calculate normal from bump map
                float3 normal = normalize(i.worldNormal);
                float3 tangentNormal = UnpackNormal(bump);
                float3 worldTangent = normalize(UnityObjectToWorldDir(float3(1,0,0)));
                float3 worldBinormal = normalize(UnityObjectToWorldDir(float3(0,1,0)));
                float3 worldNormal = normalize(i.worldNormal);
                
                // Diffuse lighting
                float NdotL = saturate(dot(worldNormal, i.lightDir));
                float3 diffuse = _SunColor.rgb * NdotL;
                
                // Specular lighting
                float3 halfVector = normalize(i.viewDir + i.lightDir);
                float NdotH = saturate(dot(worldNormal, halfVector));
                float specular = pow(NdotH, _Glossiness * 128.0) * _SpecularIntensity;
                
                // Combine lighting
                float3 finalColor = texColor.rgb * diffuse + specular;
                
                // Apply atmospheric effect
                float atmosphereEffect = saturate(1.0 - _AtmosphereThickness);
                finalColor = lerp(finalColor, _AtmosphereColor.rgb, atmosphereEffect);
                
                // Add ambient lighting
                finalColor += _AmbientColor.rgb;
                
                fixed4 col = fixed4(finalColor, texColor.a);
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}