using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderPipeline : UnityEngine.Rendering.RenderPipeline
{
    public RenderPipelineAsset rendersource;
    CommandBuffer cmd = null;

    GeometryRender geometryRender;
    static RenderPipeline()
    {
    }
    public RenderPipeline(RenderPipelineAsset rendersource)
    {
        this.rendersource = rendersource;
        geometryRender = new GeometryRender();
    }
    protected override void Render(ScriptableRenderContext renderContext, Camera[] cameras)
    {
        if (cameras.Length == 0) return;
        RenderPipeline.BeginFrameRendering(renderContext, cameras);

        foreach (var camera in cameras)
        {
            RenderPipeline.BeginCameraRendering(renderContext, camera);
            SingleCameraRender(renderContext, camera);
            RenderPipeline.EndCameraRendering(renderContext, camera);
        }

        RenderPipeline.EndFrameRendering(renderContext, cameras);

    }


    CullingResults cullResults;
    private void SingleCameraRender(ScriptableRenderContext renderContext, Camera camera)
    {

        //-------------------------Cull---------------------------
        if (camera.TryGetCullingParameters(out ScriptableCullingParameters cullParameters))
        {
            cullResults = renderContext.Cull(ref cullParameters);

        }
        else
        {
            return;
        }
        //-----------------------------------------------------------

        cmd = CommandBufferPool.Get();
        cmd.name = "Render Camera";


        //-------------------------Setup----------------------------
        renderContext.ExecuteCommandBuffer(cmd);//refresh
        cmd.Clear();
        renderContext.SetupCameraProperties(camera);
        //----------------------------------------------------------

        //scene view UI render
        if (camera.cameraType == CameraType.SceneView)
            ScriptableRenderContext.EmitWorldGeometryForSceneView(camera);


        cmd.ClearRenderTarget(true, true, Color.grey);
        renderContext.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);

        //Draw geometry
      
        GeometryRender.Render(camera,cullResults,renderContext);

        //Draw skybox
        renderContext.DrawSkybox(camera);
       
        renderContext.Submit();
    }
}
