

#ifndef _TESSELLATION_INCLUDE
#define _TESSELLATION_INCLUDE

struct TessellationFactors 
{
	float edges[3]:SV_TesseFactor;
	float inside : SV_InsideTesseFactor;
};

struct VS_OUTPUT_HS_INPUT
{
	float4 vertex:POSITION;
	float3 normal:NORMAL;
	float4 tangent:TANGENT;
	float2 texcoord:TEXCOORD0;
};


struct HS_CONTROL_POINT_OUTPUT 
{
	float4 vertex:TESSELLATION;
	float3 normal:NORMAL;
	float4 tangent:TANGENT;
	float2 texcoord:TEXCOORD0;

};

struct DS_VS_OUTOUT_PS_INPUT 
{
	float4 vertex:SV_POSITION;
	float3 normal:NORMAL;
	float4 tangent:TANGENT;
	float2 texcoord:TEXCOORD0;
};
TessellationFactors HullConstant(InputPatch<VS_OUITPUT_HS_INPUT,3> input,uint patchID:SV_PrimitiveID)
{
	TessellationFactors output;
	output.edges[0] = 0;
	output.edges[1] = 0;
	output.edges[2] = 0;
	output.inside = 0;
	return output;
}

[domain("tri")]//handl triangle
[partitioning("fractional_odd")]
[outputtopology("triangle_cw")][outputcontrolpoints(3)]
[patchconstantfunc("HullConstant")]
HS_CONTROL_POINT_OUTPUT HS(InputPatch<VS_OUTPUT_HS_INPUT, 3>input, uint id:SV_OutputControlPointID)
{
	HS_CONTROL_POINT_OUTPUT output;
	output.vertex = input[id].vertex;
	output.normal = input[id].normal;
	output.tangent= input[id].tangent;
	output.texcoord = input[id].texcoord;
	return output;
}

[domain("tri")]
DS_VS_OUTOUT_PS_INPUT DS(OutputPatch<HS_CONTROL_POINT_OUTPUT, 3>patch, float3 bary:SV_DomainLocation)
{
	DS_VS_OUTOUT_PS_INPUT output;
#define DoMainFieldName(fieldName) output.fieldName=patch[0].fieldName*bary.x\
        +patch[1].fieldName*bary.y+patch[2].fieldName*bary.z;
	    DoMainFieldName(vertex)
		DoMainFieldName(normal)
		DoMainFieldName(tangent)
		DoMainFieldName(texcoord)

		return output;
}

#endif//_TESSELLATION_INCLUDE