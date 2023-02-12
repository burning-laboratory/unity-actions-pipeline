using UnityEngine;
using UnityEngine.SceneManagement;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    /// <summary>
    /// Load scene pipeline stage.
    /// </summary>
    [AddTypeMenu("App Loader Demo/Load Scene Stage")]
    [System.Serializable]
    public class LoadSceneActionsPipelineStage : ActionsPipelineStage
    {
        [SerializeField] private string _sceneName;

        protected override void OnInit()
        {
            base.OnInit();
            
            SceneManager.sceneLoaded += OnSceneLoadedEventHandLer;
        }
        
        protected override void OnDeInit()
        {
            base.OnDeInit();
            
            SceneManager.sceneLoaded -= OnSceneLoadedEventHandLer;
        }
        
        private void OnSceneLoadedEventHandLer(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name == _sceneName)
            {
                Next(ActionsPipelineStageResult.Success);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
        }
    }
}