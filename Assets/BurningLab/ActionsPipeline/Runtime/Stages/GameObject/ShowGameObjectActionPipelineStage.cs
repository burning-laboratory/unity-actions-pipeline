using System.Collections.Generic;
using BurningLab.ActionsPipeline;
using UnityEngine;

namespace BurningLab.ActionsPipeline.Stages
{
    [AddTypeMenu("Game Object/Show Game Objects Action Pipeline Stage")]
    [System.Serializable]
    public class ShowGameObjectActionPipelineStage : ActionPipelineStage
    {
        #region Settings

        [Tooltip("Game objects list to show.")]
        [SerializeField] private List<GameObject> _gameObjects;

        #endregion

        protected override void OnStart()
        {
            base.OnStart();

            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.SetActive(true);
            }
            
            Next(ActionsPipelineStageResult.Success);
        }
    }
}