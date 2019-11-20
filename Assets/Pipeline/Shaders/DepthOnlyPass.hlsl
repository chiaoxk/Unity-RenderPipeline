
#ifndef _DEPTHONLY_INCLUDE_
#define _DEPTHONLY_INCLUDE_

sampler2D _MainTex;

struct AttributesMesh {

	float4 positionOS:POSITION;
	float2 texcoord:TEXCOORD0;
};
struct VaryingMeshToPS {


	float4 positionCS:SV_POSITION;

	float2 texcoord:TEXCOORD0;
};

VaryingMeshToPS Vert_Depth(AttributesMesh input)
{
	VaryingMeshToPS output;

	UNITY_SETUP_INSTANCE_ID(input);

	UNITY_TRANSFER_INSTANCE_ID(input, output);

	output.positionCS = UnityObjectToClipPos(input.positionOS);
	output.texcoord = input.texcoord;

	return output;
}
#ifdef TESSELLATION_ON

#endif
void Frag_Depth(VaryingMeshToPS input)
{
#ifdef ALPHATEST_ON
	//DoAlphaTest()
	float a = tex2D(_MainTex, input.texcoord).a;
	clip(a*_Tint.a - _AlphaCutoff);
#endif
}

#endif//_DEPTHONLY_INCLUDE