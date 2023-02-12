using UnityEngine;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Mark Game Object As Dont Destroy On Load Stage")]
    [System.Serializable]
    public class MarkGameObjectAsDontDestroyOnLoadActionsPipelineStage : ActionsPipelineStage
    {
        [SerializeField] private GameObject _targetGameObject;
        
        protected override void OnStart()
        {
            base.OnStart();
            
            Object.DontDestroyOnLoad(_targetGameObject);
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}