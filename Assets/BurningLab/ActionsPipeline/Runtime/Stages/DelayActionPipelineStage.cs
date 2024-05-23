using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    /// <summary>
    /// Delay actions pipeline stage.
    /// </summary>
    [AddTypeMenu("Misc/Delay Stage")]
    [System.Serializable]
    public class DelayActionPipelineStage : ActionPipelineStage
    {
        [Tooltip("Delay in seconds.")]
        [SerializeField] private float _secondsDelay;
        
        /// <summary>
        /// Cancellation token for async operation.
        /// </summary>
        private CancellationTokenSource _cancellationToken;
        
        protected override void OnStart()
        {
            base.OnStart();

            _cancellationToken = new CancellationTokenSource();
            Delay(_secondsDelay, _cancellationToken.Token);
        }

        protected override void OnDeInit()
        {
            base.OnDeInit();
            
            _cancellationToken.Cancel();
        }

        protected override void OnCancel()
        {
            base.OnCancel();
            
            _cancellationToken.Cancel();
        }

        /// <summary>
        /// Delay methods.
        /// </summary>
        /// <param name="seconds">Seconds to delay.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        private async void Delay(float seconds, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay((int) (seconds * 1000), cancellationToken);
                Next(ActionsPipelineStageResult.Success);
            }
            catch (OperationCanceledException)
            {
                Next(ActionsPipelineStageResult.Cancelled);
            }
        }
    }
}