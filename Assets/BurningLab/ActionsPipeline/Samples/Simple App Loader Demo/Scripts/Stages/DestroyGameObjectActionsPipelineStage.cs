using UnityEngine;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Destory Game Object Stage")]
    [System.Serializable]
    public class DestroyGameObjectActionsPipelineStage : ActionsPipelineStage
    {
        [SerializeField] private GameObject _gameObjectToDestroy;
        
        protected override void OnStart()
        {
            base.OnStart();
            
            Object.Destroy(_gameObjectToDestroy);
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}