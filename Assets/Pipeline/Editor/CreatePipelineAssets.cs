using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class PipelineAssetsFactory
{
    [MenuItem("Assets/Rendering/Create New PipelineAssets")]
    static void CreatePipelineAssets()
    {
        //var newAssets = ScriptableObject.CreateInstance<RenderPipelineAsset>();
        //newAssets.name = PipelineUtil.DefaultPipelineAssetsName;
        //AssetDatabase.CreateAsset(newAssets, PipelineUtil.GetPipelineAssetsPath());
        var icon = EditorGUIUtility.FindTexture("");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateCallBack>(), "DefaultAssets.asset", icon, null);
    }

    public class CreateCallBack : UnityEditor.ProjectWindowCallback.EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {

            var newAsset = ScriptableObject.CreateInstance<RenderPipelineAsset>();
            var assetName = Path.GetFileName(pathName);
            newAsset.name = assetName;

            AssetDatabase.CreateAsset(newAsset, PipelineUtil.GetPipelineAssetsPath());
            ProjectWindowUtil.ShowCreatedAsset(newAsset);

        }
    }

}
