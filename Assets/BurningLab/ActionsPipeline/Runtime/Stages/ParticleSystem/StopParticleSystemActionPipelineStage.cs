using BurningLab.ActionsPipeline;
using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    [AddTypeMenu("Particle System/Stop Particle System Action")]
    [System.Serializable]
    public class StopParticleSystemActionPipelineStage : ActionPipelineStage
    {
        #region Settings

        [Tooltip("Target particle system reference.")]
        [SerializeField] private ParticleSystem _particleSystem;
        
        [Tooltip("Include child particles systems to stop.")]
        [SerializeField] private bool _withChildren;
        
        [Tooltip("Particle system stop mode.")]
        [SerializeField] private ParticleSystemStopBehavior _stopBehavior;

        #endregion

        #region Virtual Methods

        protected override void OnStart()
        {
            base.OnStart();
            
            _particleSystem.Stop(_withChildren, _stopBehavior);
            Next(ActionsPipelineStageResult.Success);
        }

        #endregion
    }
}