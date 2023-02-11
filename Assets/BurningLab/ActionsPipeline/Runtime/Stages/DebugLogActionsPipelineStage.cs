using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    /// <summary>
    /// Print message to unity console stage.
    /// </summary>
    [AddTypeMenu("Burning-Lab/Misc/Debug Log Stage")]
    [System.Serializable]
    public class DebugLogActionsPipelineStage : ActionsPipelineStage
    {
        [SerializeField] private string _message;
        
        protected override void OnStart()
        {
            base.OnStart();
            
            Debug.Log(_message);
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}