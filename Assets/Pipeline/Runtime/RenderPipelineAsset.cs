using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderPipelineAsset : UnityEngine.Rendering.RenderPipelineAsset
{
    protected override UnityEngine.Rendering.RenderPipeline CreatePipeline()
    {
        return new RenderPipeline(this);
    }

    [SerializeField]
    RenderpipelineResource pipelineResource;

    public RenderpipelineResource PipelineResource
    {
        get => pipelineResource;
        set => pipelineResource = value;
    }

}
