Shader "Unlit/NormalmapTest1"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BumpMap("Normalmap", 2D) = "bump" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float3 normal : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _BumpMap;

			v2f vert (appdata_base v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.normal = UnityObjectToWorldNormal(v.normal);;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float4 col;
				//float3 bump = tex2D(_BumpMap, i.uv);
				float3 bump = UnpackNormal(tex2D(_BumpMap, i.uv));

				float3 v_n = UnityObjectToWorldNormal(bump);
				//float3 v_n = UnityObjectToWorldNormal(bump);

				//col.rgb = v_n * 0.5 + 0.5;
				//col.rgb = bump;
				//col.rgb = normalize(v_n + i.normal) * 0.5 + 0.5;
				col.rgb = v_n * 0.5 + 0.5;

				return col;
			}
			ENDCG
		}
	}
}
