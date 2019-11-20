
Shader"RP/Lit"
{
	Properties
	{
	_MainTex("Base", 2D) = "white"{}
	_Tint("Tint",Color) = (1,1,1,1)

	[Gamma]_Metallic("Metallic",Range(0.0,1.0)) = 0.0
	_Smoonthness("Smoothness",Range(0.0,1.0)) = 0.5
	

    _AlphaCutoff("Alpha Cutoff",Range(0.0,1.0))=0.5
	[HDR]_EmissionColor("Emission Color",Color)=(1,1,1,1)
	}

		HLSLINCLUDE

#pragma target 4.5
#include "UnityCG.cginc"
		//includes
#include "DepthOnlyPass.hlsl"
#include "GBufferPass.hlsl"
#pragma shader_feature _ALPHATEST_ON
		//enable GPU instancing support
#pragma multi_compile_instancing
		ENDHLSL


	SubShader
	{

	Tags
	{
	 "RenderPipeline" = "URenderPipeline"
	 "RenderType" = "LitRender"
	}
	/*Pass
	{
		Name "GenerallLit"
		Tags{"LightMode" = "GenerallLit"}
		Cull Off
		HLSLPROGRAM

		ENDHLSL
	}
	Pass
	{

		Name "GBuffer"
		Tags{"LightMode"="GBuffer"}
		HLSLPROGRAM
		ENDHLSL

	}*/
	Pass
	{
		Name "DepthOnly"
		Tags{"LightMode"="DepthOnly"}
		//Cull[_CullMode]

		/*Stencil
	    {
		WriteMask[]
		Ref[]
		Comp Always
		Pass Replace

	    }*/
		HLSLPROGRAM
        #pragma vertex Vert_Depth
        #pragma fragment Frag_Depth

		ENDHLSL

	}
	/*Pass
	{
	Name "ShadowCaster"
	Tags{"LightMode" = "ShadowCaster"}
		HLSLPROGRAM
		ENDHLSL
	}

	Pass
	{
	  Name "Meta"
	  Tags{"LightMode"="Meta"}
		HLSLPROGRAM
		ENDHLSL
	}*/
	

	}
	
}