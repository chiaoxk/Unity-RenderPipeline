using UnityEngine;
using UnityEngine.Rendering;

public class GeometryRender
{


    public static void Render(Camera cam, CullingResults cull, ScriptableRenderContext context)
    {

        var sortingSettings = new SortingSettings(cam)
        {
            criteria = SortingCriteria.CommonOpaque,
        };
        //how to filter the given set of visible object to render

        //how to sort visible objects are sorted and which shader pass to use
        var drawSettings = new DrawingSettings(new ShaderTagId("DepthOnly"), sortingSettings)
        {
            perObjectData = PerObjectData.None,
        };
        //drawSettings.enableDynamicBatching = true;
        //drawSettings.enableInstancing = true;
        //drawSettings.overrideMaterial = null;//sets the material to use for all drawer that would render in this group
        //drawSettings.overrideMaterialPassIndex = 0;



        var filterSettings = new FilteringSettings()
        {
            layerMask = cam.cullingMask,//only render objects in the given layer mask
            renderingLayerMask = 1,//用于过滤绘图时可用的渲染器
            renderQueueRange = new RenderQueueRange(2000, 2499)//render whose material render queue in this range
        };

        //RenderStateBlock stateBlock = new RenderStateBlock()
        //{

        //};
        context.DrawRenderers(cull, ref drawSettings, ref filterSettings);
    }

}
