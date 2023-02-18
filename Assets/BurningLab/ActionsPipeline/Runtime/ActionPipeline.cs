using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Actions pipeline structure.
    /// </summary>
    [Serializable]
    public struct ActionPipeline
    {
        #region Settings

        [SerializeReference, SubclassSelector] private List<ActionPipelineStage> _pipelineStages;

        #endregion

        #region Private Fields
        
        /// <summary>
        /// Actions pipeline stages queue.
        /// </summary>
        private Queue<ActionPipelineStage> _pipelineStagesQueue;

        #endregion

        #region Public Fields
        
        /// <summary>
        /// Stages count in actions pipeline.
        /// </summary>
        public int StagesCount => _pipelineStages.Count;

        /// <summary>
        /// Actions pipeline complete progress.
        /// </summary>
        public float Progress
        {
            get
            {
                float startStagesCount = _pipelineStages.Count(s => s.IncludeForProgressComputing);
                float leftStagesCount = _pipelineStagesQueue.Count(s => s.IncludeForProgressComputing);
                float completedStagesCount = startStagesCount - leftStagesCount;
                return completedStagesCount / startStagesCount;
            }
        }
        
        /// <summary>
        /// Actions pipeline is done.
        /// </summary>
        public bool IsDone => _pipelineStagesQueue.Count == 0;

        #endregion
        
        #region Events
        
        /// <summary>
        /// On actions pipeline complete event.
        /// </summary>
        public event Action<ActionPipelineResult> OnPipelineComplete;
        
        /// <summary>
        /// On actions pipeline stage start event.
        /// </summary>
        public event Action<ActionPipelineStage> OnPipelineStageStart;
        
        /// <summary>
        /// On actions pipeline stave complete event.
        /// </summary>
        public event Action<ActionPipelineStage> OnPipelineStageEnd; 

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handle stage complete event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="result">Sender stage result.</param>
        private void OnActionsPipelineStageEndEventHandler(IActionPipelineStage sender, ActionsPipelineStageResult result)
        {
            OnPipelineStageEnd?.Invoke((ActionPipelineStage) sender);
            sender.DeInit();
            sender.OnStageEnd -= OnActionsPipelineStageEndEventHandler;

            switch (result)
            {
                case ActionsPipelineStageResult.Success:
                case ActionsPipelineStageResult.Skipped:
                    if (_pipelineStagesQueue.Count != 0)
                    {
                        IActionPipelineStage nextStage = _pipelineStagesQueue.Dequeue();
                        RunStage((ActionPipelineStage) nextStage);
                    }
                    else
                    {
                        OnPipelineComplete?.Invoke(ActionPipelineResult.Success);
                    }
                    break;
                
                case ActionsPipelineStageResult.Error:
                    OnPipelineComplete?.Invoke(ActionPipelineResult.Error);
                    break;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Run pipeline stage.
        /// </summary>
        /// <param name="stage">Stage to run.</param>
        private void RunStage(ActionPipelineStage stage)
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
            _pipelineStagesQueue ??= new Queue<ActionPipelineStage>();
            
            foreach (ActionPipelineStage pipelineStage in _pipelineStages)
                _pipelineStagesQueue.Enqueue(pipelineStage);
            
            RunStage(_pipelineStagesQueue.Dequeue());
        }

        #endregion
    }
}
