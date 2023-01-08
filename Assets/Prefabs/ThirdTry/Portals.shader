Shader "Custom/Portals" {
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _Alpha("Alpha", Range(0,1)) = 0.5
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 3.0
                #pragma multi_compile __ UNITY_2018_3_OR_NEWER
                #if UNITY_2018_3_OR_NEWER
                    #pragma dependency on _CameraDepthTexture
                #endif

                sampler2D _MainTex;
                fixed4 _Color;
                float _Alpha;

                struct VertexInput {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct VertexOutput {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                VertexOutput vert(VertexInput input) {
                    VertexOutput output;
                    output.pos = UnityObjectToClipPos(input.vertex);
                    output.uv = input.uv;
                    return output;
                }

                half4 frag(VertexOutput input) : SV_Target{
                    #if UNITY_2018_3_OR_NEWER
                        fixed4 c = lerp(_Color, tex2D(_CameraDepthTexture, input.uv), _Alpha);
#else
                    fixed4 c = _Color;
#endif
                return c;
                }
                    ENDCG
    }
    }
        FallBack "Diffuse"
}   