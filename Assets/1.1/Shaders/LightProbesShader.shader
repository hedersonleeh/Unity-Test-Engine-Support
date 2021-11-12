Shader "MyShader/Diffuse With LightProbes" {
    Properties { [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {} }
    SubShader {
        Pass {
            Tags {
                "LightMode"="ForwardBase"
            }
            CGPROGRAM
            
            #pragma vertex v
            #pragma fragment f
            // Specify the target
            #pragma target 3.0
            #include "UnityCG.cginc"
            // You must include this header to have access to ShadeSHPerPixel
            #include "UnityStandardUtils.cginc"
            sampler2D _MainTex;
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 normal : TEXCOORD1;
                float4 vertex : SV_POSITION;
                float4 wPos :TEXCOORD2;
            };
            v2f v (appdata_base vertex_data) {
                v2f o;
                o.vertex = UnityObjectToClipPos(vertex_data.vertex);
                o.normal.xyz = UnityObjectToWorldNormal(vertex_data.normal);
                
                o.wPos = mul( unity_ObjectToWorld, vertex_data.vertex );

                o.uv = vertex_data.texcoord;
                return o;
            }
            fixed4 f (v2f i) : SV_Target {
                
                half3 currentAmbient = half3(0, 0, 0);
                float3 ambient = ShadeSHPerPixel(normalize(i.normal), currentAmbient, i.wPos);

                return float4(ambient,1  );
            }
            ENDCG
        }
    }
}
