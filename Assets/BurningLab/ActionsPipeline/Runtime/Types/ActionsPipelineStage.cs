using System;
using UnityEngine;

namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Root actions pipeline stage class.
    /// </summary>
    [Serializable]
    public abstract class ActionsPipelineStage : IActionsPipelineStage
    {
        #region Settings
        
        [Tooltip("Actions pipeline stage name.")]
        [SerializeField] protected string _stageName;

        [Tooltip("If enabled, the passage of this stage is taken into account in the overall progress of the pipeline.")]
        [SerializeField] private bool _includeForProgressComputing;
        
        public string StageName => _stageName;

        public bool IncludeForProgressComputing => _includeForProgressComputing;
        
        #endregion

        #region Interface Implementation

        /// <summary>
        /// Initialize stage.
        /// </summary>
        public void Init()
        {
            OnInit();
        }
        
        /// <summary>
        /// Deinitialize stage.
        /// </summary>
        public void DeInit()
        {
            OnDeInit();
        }
        
        /// <summary>
        /// Run stage.
        /// </summary>
        public void Start()
        {
            OnStageStarted?.Invoke(this);
            OnStart();
        }
        
        /// <summary>
        /// Call next stage.
        /// </summary>
        /// <param name="stageResult"></param>
        protected void Next(ActionsPipelineStageResult stageResult)
        {
            OnStageEnd?.Invoke(this, stageResult);
        }
        
        /// <summary>
        /// On stage started event.
        /// </summary>
        public event Action<IActionsPipelineStage> OnStageStarted;
        
        /// <summary>
        /// On stage end event.
        /// </summary>
        public event Action<IActionsPipelineStage, ActionsPipelineStageResult> OnStageEnd;

        #endregion

        #region Virtual Methods
        
        /// <summary>
        /// Stage init virtual method.
        /// </summary>
        protected virtual void OnInit(){ }
        
        /// <summary>
        /// Stage deinit virtual method.
        /// </summary>
        protected virtual void OnDeInit(){ }
        
        /// <summary>
        /// Stage start virtual method.
        /// </summary>
        protected virtual void OnStart(){ }

        #endregion
    }
}