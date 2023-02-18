using UnityEngine;
using UnityEngine.SceneManagement;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Unload Scene Stage")]
    [System.Serializable]
    public class UnloadSceneActionPipelineStage : ActionPipelineStage
    {
        [SerializeField] private string _sceneNameToUnload;

        private void OnSceneUnLoadedEventHandler(Scene unloadedScene)
        {
            if (unloadedScene.name == _sceneNameToUnload)
            {
                Next(ActionsPipelineStageResult.Success);
            }   
        }
        
        protected override void OnInit()
        {
            base.OnInit();

            SceneManager.sceneUnloaded += OnSceneUnLoadedEventHandler;

        }
        
        protected override void OnDeInit()
        {
            base.OnDeInit();
            
            SceneManager.sceneUnloaded -= OnSceneUnLoadedEventHandler;
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            SceneManager.UnloadSceneAsync(_sceneNameToUnload);
        }
    }
}