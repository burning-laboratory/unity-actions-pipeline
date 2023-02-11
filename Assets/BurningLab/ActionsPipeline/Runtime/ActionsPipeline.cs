using System;
using System.Collections.Generic;
using UnityEngine;

namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Actions pipeline structure.
    /// </summary>
    [Serializable]
    public struct ActionsPipeline
    {
        #region Settings

        [SerializeReference, SubclassSelector] private List<ActionsPipelineStage> _pipelineStages;

        #endregion

        #region Private Fields
        
        /// <summary>
        /// Actions pipeline stages queue.
        /// </summary>
        private Queue<ActionsPipelineStage> _pipelineStagesQueue;

        #endregion

        #region Events
        
        /// <summary>
        /// On actions pipeline complete event.
        /// </summary>
        public event Action OnPipelineComplete;
        
        /// <summary>
        /// On actions pipeline stage start event.
        /// </summary>
        public event Action<ActionsPipelineStage> OnPipelineStageStart;
        
        /// <summary>
        /// On actions pipeline stave complete event.
        /// </summary>
        public event Action<ActionsPipelineStage> OnPipelineStageEnd; 

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handle stage complete event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="result">Sender stage result.</param>
        private void OnActionsPipelineStageEndEventHandler(IActionsPipelineStage sender, ActionsPipelineStageResult result)
        {
            OnPipelineStageEnd?.Invoke((ActionsPipelineStage) sender);
            sender.DeInit();
            sender.OnStageEnd -= OnActionsPipelineStageEndEventHandler;

            switch (result)
            {
                case ActionsPipelineStageResult.Success:
                    if (_pipelineStagesQueue.Count != 0)
                    {
                        IActionsPipelineStage nextStage = _pipelineStagesQueue.Dequeue();
                        RunStage((ActionsPipelineStage) nextStage);
                    }
                    else
                    {
                        OnPipelineComplete?.Invoke();
                    }
                    break;
                
                case ActionsPipelineStageResult.Error:
                    break;
                
                case ActionsPipelineStageResult.Skipped:
                    break;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Run pipeline stage.
        /// </summary>
        /// <param name="stage">Stage to run.</param>
        private void RunStage(ActionsPipelineStage stage)
        {
            stage.OnStageEnd += OnActionsPipelineStageEndEventHandler;
            stage.Init();
            OnPipelineStageStart?.Invoke(stage);
            stage.Start();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start running actions pipeline.
        /// </summary>
        public void RunPipeline()
        {
            _pipelineStagesQueue ??= new Queue<ActionsPipelineStage>();
            
            foreach (ActionsPipelineStage pipelineStage in _pipelineStages)
                _pipelineStagesQueue.Enqueue(pipelineStage);
            
            RunStage(_pipelineStagesQueue.Dequeue());
        }

        #endregion
    }
}
