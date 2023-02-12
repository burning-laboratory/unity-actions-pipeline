using UnityEngine;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Instantiate Game Object Stage")]
    [System.Serializable]
    public class InstantiateGameObjectActionsPipelineStage : ActionsPipelineStage
    {
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private GameObject _prefab;
        
        protected override void OnStart()
        {
            base.OnStart();

            Object.Instantiate(_prefab, _parentTransform);
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}