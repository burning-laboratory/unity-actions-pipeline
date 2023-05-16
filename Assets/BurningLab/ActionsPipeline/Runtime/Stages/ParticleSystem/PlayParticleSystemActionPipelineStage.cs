using BurningLab.ActionsPipeline;
using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    [AddTypeMenu("Particle System/Play Particle System")]
    [System.Serializable]
    public class PlayParticleSystemActionPipelineStage : ActionPipelineStage
    {
        #region Settings

        [Tooltip("Particle system to play.")]
        [SerializeField] private ParticleSystem _particleSystem;

        #endregion

        #region Virtual Methods

        /// <summary>
        /// On action pipeline start event handler.
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            _particleSystem.Play();
            Next(ActionsPipelineStageResult.Success);
        }

        #endregion
    }
}