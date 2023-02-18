using UnityEngine;
using UnityEngine.SceneManagement;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Mark Scene As Active Stage")]
    [System.Serializable]
    public class MarkSceneAsActiveActionPipelineStage : ActionPipelineStage
    {
        [SerializeField] private string _sceneNameToMarkAsActive;
        
        protected override void OnStart()
        {
            base.OnStart();
            
            Scene targetScene = SceneManager.GetSceneByName(_sceneNameToMarkAsActive);
            SceneManager.SetActiveScene(targetScene);
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}