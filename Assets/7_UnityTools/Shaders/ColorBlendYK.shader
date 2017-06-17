// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/BlendColorYK" {
	Properties{
		_MainTex("Base", 2D) = "white" {}
		_TintColor("TintColor", Color) = (0.5, 0.5, 0.5, 0.5)
		_Blending("_Blending", Range(0.0, 1.0)) = 0.5
	}

		CGINCLUDE

#include "UnityCG.cginc"

	sampler2D _MainTex;
	fixed4 _TintColor;
	fixed _Blending;

	struct v2f {
		half4 pos : SV_POSITION;
		half2 uv : TEXCOORD0;
	};

	v2f vert(appdata_full v) {
		v2f o;

		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv.xy = v.texcoord.xy;

		return o;
	}

	fixed4 frag(v2f i) : COLOR{
	fixed4 col = tex2D(_MainTex, i.uv.xy);
	return lerp(col, _TintColor, _Blending) * col.a;
	
	}

		ENDCG

		SubShader {
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
			Cull Off
			Lighting Off
			ZWrite Off
			Fog{ Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha

			Pass{

			CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 

			ENDCG

		}

	}
	FallBack Off
}