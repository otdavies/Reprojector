// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Unlit shader. Simplest possible textured shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Unlit/Video" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "black" {}
        _GridEnabled("GridEnabled", Int) = 0
        _GridWidth("GridWidth", Float) = 2
        _GridStep("GridStep", Float) = 0.05
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 2.0

                #include "UnityCG.cginc"

                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                    float2 texcoord : TEXCOORD0;
                    UNITY_VERTEX_OUTPUT_STEREO
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                int _GridEnabled;
                float _GridWidth;
                float _GridStep;

                v2f vert (appdata_t v)
                {
                    v2f o;
                    UNITY_SETUP_INSTANCE_ID(v);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }

                fixed4 frag (v2f i) : SV_Target
                {
                    float2 uv = i.texcoord;
                    fixed4 col = tex2D(_MainTex, uv);
                    float grid = 0;

                    if(_GridEnabled == 1) {
                        float2 pos = uv / _GridStep;
                        float2 f  = abs(frac(pos)-.5);
                        float2 df = fwidth(pos) * _GridWidth;
                        float2 g = smoothstep(-df ,df , f);
                        grid = 1.0 - saturate(g.x * g.y);
                    }

                    UNITY_OPAQUE_ALPHA(col.a);
                    return lerp(col.rgba, float4(0.5,0.5,0.5,1), grid);
                }
            ENDCG
        }
    }
}