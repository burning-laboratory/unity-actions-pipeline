using UnityEngine;
using UnityEngine.SceneManagement;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Move Game Object To Scene Stage")]
    [System.Serializable]
    public class MoveGameObjectToSceneActionPipelineStage : ActionsPipelineStage
    {
        [Tooltip("Game object for move.")]
        [SerializeField] private GameObject _gameObject;
        
        [Tooltip("Target scene name.")]
        [SerializeField] private string _targetSceneName;
        
        protected override void OnStart()
        {
            base.OnStart();

            Scene targetScene = SceneManager.GetSceneByName(_targetSceneName);
            
            SceneManager.MoveGameObjectToScene(_gameObject, targetScene);
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}