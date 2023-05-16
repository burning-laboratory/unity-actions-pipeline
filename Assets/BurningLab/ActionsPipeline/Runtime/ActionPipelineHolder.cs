using BurningLab.ActionsPipeline;
using UnityEngine;

namespace BurningLab.ActionsPipeline
{
    public class ActionPipelineHolder : MonoBehaviour
    {
        [Tooltip("Holding actions pipeline.")]
        [SerializeField] private ActionPipeline _actionPipeline;
        
        /// <summary>
        /// Holding action pipeline.
        /// </summary>
        public ActionPipeline ActionPipeline => _actionPipeline;
    }
}