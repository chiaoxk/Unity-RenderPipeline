

struct SurfaceData {

	float3 albedo;
	float3 specular;
	float occlusion;
	float smoothness;
	float3 normal;

};

texture2D _GBufferTexture0;
texture2D _GBufferTexture1;
texture2D _GBufferTexture2;
texture2D _GBufferTexture3;

frag_GBuffer(out GBuffer0:SV_Target0,out GBuffer1:SV_Target1,out GBuffer2:SV_Target2,out GBuffer3:SV_Target3,out GBuffer4:SV_Target4)
{

}