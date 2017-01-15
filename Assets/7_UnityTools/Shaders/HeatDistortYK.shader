// By Yunkyu Choi
// Fixed for Unity 5
// Jan. 12. 2017

Shader "Distort_YK"
{
	Properties{
		_BumpAmt("Distortion", range(0,1)) = 0.1
		_BumpMap("Normalmap", 2D) = "bump" {}
	}

		SubShader
	{
		// We must be transparent, so other objects are drawn before this one.
		Tags{ "Queue" = "Transparent+100" "RenderType" = "Opaque" }


		// Grab the screen behind the object into _BackgroundTexture
		GrabPass
	{
		"_BackgroundTexture"
	}

		// Render the object with the texture generated above, and invert the colors
		Pass
	{
CGPROGRAM
#pragma fragmentoption ARB_precision_hint_fastest
#pragma fragmentoption ARB_fog_exp2
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"


		struct v2f
	{

		float3 uvbump : TEXCOORD0;
		float4 grabPos : TEXCOORD1;
		float4 pos : SV_POSITION;
	};


	v2f vert(appdata_base v) {
		v2f o;
		// use UnityObjectToClipPos from UnityCG.cginc to calculate 
		// the clip-space of the vertex
		o.pos = UnityObjectToClipPos(v.vertex);

		// use ComputeGrabScreenPos function from UnityCG.cginc
		// to get the correct texture coordinate
		o.grabPos = ComputeGrabScreenPos(o.pos);

		o.uvbump = float3(v.texcoord.xy, 0);

		return o;
	}


	uniform float _BumpAmt;
	sampler2D _BumpMap;
	sampler2D _BackgroundTexture;
	float4 _BackgroundTexture_TexelSize;


	half4 frag(v2f i) : SV_Target
	{
		// Step 1: UV
		/*half3 bump = i.uvbump;
		half4 bgcolor = half4(bump.r, bump.g, bump.b, 0.0);
		return bgcolor;*/

		// Step 2: Image
		/*half3 bump = tex2D(_BumpMap, i.uvbump);
		half4 bgcolor = half4(bump.r, bump.g, bump.b, 0.0);
		return bgcolor;*/

		// Step 3: Unpack Normal
		/*half3 bump = UnpackNormal(tex2D(_BumpMap, i.uvbump));
		half4 bgcolor = half4(bump.r, bump.g, bump.b, 0.0);
		return bgcolor;*/

		/*half3 bump = UnpackNormal(tex2D(_BumpMap, i.uvbump));
		half4 bumpProj =  half4(bump.r, bump.g, bump.b, 0.0);
		half4 bgcolor = (i.grabPos + bumpProj) * _BumpAmt;
		return bgcolor;*/

		/*
		half4 temp = (i.grabPos.w * _BumpAmt, i.grabPos.w * _BumpAmt, i.grabPos.w * _BumpAmt, i.grabPos.w * _BumpAmt) ;
		return temp;
		*/

		// Step 4: Move
		/*half3 bump = UnpackNormal(tex2D(_BumpMap, i.uvbump));
      half4 bumpProj =  half4(bump.r, bump.g, bump.b, 0.0) ;
		half4 bgcolor = tex2Dproj(_BackgroundTexture, i.grabPos + bumpProj * _BumpAmt);
		return bgcolor;*/

		// Step 5: More exact expression
		half2 bump = UnpackNormal(tex2D(_BumpMap, i.uvbump)).rg * _BumpAmt;
      half4 bumpProj =  half4(bump.r + i.grabPos.x, 
										bump.g + i.grabPos.y, 
										 0.0, 
										 i.grabPos.w);
		half4 bgcolor = tex2Dproj(_BackgroundTexture, bumpProj);
		return bgcolor;

	}

		ENDCG
	}

	}
}