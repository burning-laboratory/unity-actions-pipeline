using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    /// <summary>
    /// Print message to unity console stage.
    /// </summary>
    [AddTypeMenu("Misc/Debug Log Stage")]
    [System.Serializable]
    public class DebugLogActionPipelineStage : ActionPipelineStage
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