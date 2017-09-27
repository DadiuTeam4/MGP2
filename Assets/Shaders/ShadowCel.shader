//Author Peter Jæger

Shader "Custom/Shadow and Cel" {

	Properties {
		_Tint ("Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Albedo", 2D) = "white" {}

		[NoScaleOffset] _NormalMap ("Normals", 2D) = "bump" {}
		_BumpScale ("Bump Scale", Float) = 1

		//[NoScaleOffset] _MetallicMap ("Metallic", 2D) = "white" {}
		//[Gamma] _Metallic ("Metallic", Range(0, 1)) = 0
		_Smoothness ("Smoothness", Range(0, 1)) = 0.1

		//[NoScaleOffset] _OcclusionMap ("Occlusion", 2D) = "white" {}
		//_OcclusionStrength("Occlusion Strength", Range(0, 1)) = 1

		//[NoScaleOffset] _EmissionMap ("Emission", 2D) = "black" {}
		//_Emission ("Emission", Color) = (0, 0, 0)

		//[NoScaleOffset] _DetailMask ("Detail Mask", 2D) = "white" {}
		//_DetailTex ("Detail Albedo", 2D) = "gray" {}
		//[NoScaleOffset] _DetailNormalMap ("Detail Normals", 2D) = "bump" {}
		//_DetailBumpScale ("Detail Bump Scale", Float) = 1

		_ShadowTex		("Shadow", 2D) = "white" {}
		_ShadowNoise	("Shadow Noise", 2D) = "white" {}
		_ShadowTiling	("Shadow Tiling", Range (0.1,10)) = 1
		_ShadowInMainTex ("Shadow in Albedo", Range (0,1)) = 0.1
		_ShadowBrightness ("Shadow Brightness", Range (0,1)) = 0.1
		//_ShadowInMainTexBrightness ("Shadow in Albedo Brightness", Range (0,1)) = 0.1

		_OutlineColor	("Outline Color", Color) = (0,0,0,1)
		_Outline		("Outline width", Range (0.0, 0.1)) = .05
	}

	CGINCLUDE

	#define BINORMAL_PER_FRAGMENT
	#include "UnityCG.cginc"
	struct appdata {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	};
 
	struct v2f {
		float4 pos : POSITION;
		float4 color : COLOR;
	};

	uniform float _Outline;
	uniform float4 _OutlineColor;


	v2f vert(appdata v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
 
		float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
		float2 offset = TransformViewToProjection(norm.xy);
 
		o.pos.xy += offset * o.pos.z * _Outline;
		o.color = _OutlineColor;
		return o;
	}
	ENDCG

	SubShader {

		
 
		Pass {
			Tags {
				"LightMode" = "ForwardBase"
			}

			CGPROGRAM

			#pragma target 3.0

			
			#pragma shader_feature _METALLIC_MAP 
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _NORMAL_MAP
			#pragma shader_feature _OCCLUSION_MAP
			#pragma shader_feature _EMISSION_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP
			#pragma shader_feature _DETAIL_NORMAL_MAP

			#pragma multi_compile _ SHADOWS_SCREEN
			#pragma multi_compile _ VERTEXLIGHT_ON

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#define FORWARD_BASE_PASS

			#include "My Lighting.cginc"

			ENDCG
		}

		Pass {
			Tags {
				"LightMode" = "ForwardAdd"
			}

			Blend One One
			ZWrite Off

			CGPROGRAM

			#pragma target 3.0

			#pragma shader_feature _METALLIC_MAP
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _NORMAL_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP
			#pragma shader_feature _DETAIL_NORMAL_MAP
			#pragma shader_feature _ShadowTex

			#pragma multi_compile_fwdadd_fullshadows
			
			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "My Lighting.cginc"

			ENDCG
		}

		Pass {
			Tags {
				"LightMode" = "ShadowCaster"
				"RenderType"="Transparent"
			}

			CGPROGRAM

			#pragma target 3.0

			#pragma multi_compile_shadowcaster

			#pragma vertex MyShadowVertexProgram
			#pragma fragment MyShadowFragmentProgram

			#include "My Shadows.cginc"

			ENDCG
		}

		Pass {
			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull front
			ZWrite Off
			//ZTest Always
			ColorMask RGB // alpha not used
 
			// you can choose what kind of blending mode you want for the outline
			Blend SrcAlpha OneMinusSrcAlpha // Normal
			//Blend One One // Additive
			//Blend One OneMinusDstColor // Soft Additive
			//Blend DstColor Zero // Multiplicative
			//Blend DstColor SrcColor // 2x Multiplicative
 
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
 
			half4 frag(v2f i) :COLOR {
			return i.color;
			}
			ENDCG
		}
	}


	//CustomEditor "MyLightingShaderGUI"
}