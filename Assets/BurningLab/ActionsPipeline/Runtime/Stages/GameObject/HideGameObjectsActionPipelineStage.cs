using System.Collections.Generic;
using BurningLab.ActionsPipeline;
using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    [AddTypeMenu("Game Object/Hide Game Objects Action Pipeline Stage")]
    [System.Serializable]
    public class HideGameObjectsActionPipelineStage : ActionPipelineStage
    {
        #region Settings

        [Tooltip("Game objects list to hide.")]
        [SerializeField] private List<GameObject> _gameObjects;

        #endregion

        protected override void OnStart()
        {
            base.OnStart();

            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.SetActive(false);
            }
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}