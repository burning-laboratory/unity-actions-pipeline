using System;

namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Actions pipeline stage interface.
    /// </summary>
    public interface IActionPipelineStage
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
        
        /// <summary>
        /// Cancel action pipeline stage.
        /// </summary>
        public void Cancel();
        
        #endregion

        #region Stage Events

        /// <summary>
        /// Stage started event.
        /// </summary>
        public event Action<IActionPipelineStage> OnStageStarted;
        
        /// <summary>
        /// Stage end event.
        /// </summary>
        public event Action<IActionPipelineStage, ActionsPipelineStageResult> OnStageEnd;

        #endregion
    }
}