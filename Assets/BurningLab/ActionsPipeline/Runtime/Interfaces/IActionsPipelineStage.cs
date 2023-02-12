using System;
using BurningLab.ActionsPipeline;

namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Actions pipeline stage interface.
    /// </summary>
    public interface IActionsPipelineStage
    {
        #region Stage Initialization

        /// <summary>
        /// Initialize custom actions pipeline stage.
        /// </summary>
        public void Init();
        
        /// <summary>
        /// De initialize custom actions pipeline stage.
        /// </summary>
        public void DeInit();

        #endregion

        #region Stage Control

        /// <summary>
        /// Run actions pipeline stage.
        /// </summary>
        public void Start();

        #endregion

        #region Stage Events

        /// <summary>
        /// Stage started event.
        /// </summary>
        public event Action<IActionsPipelineStage> OnStageStarted;
        
        /// <summary>
        /// Stage end event.
        /// </summary>
        public event Action<IActionsPipelineStage, ActionsPipelineStageResult> OnStageEnd;

        #endregion
    }
}