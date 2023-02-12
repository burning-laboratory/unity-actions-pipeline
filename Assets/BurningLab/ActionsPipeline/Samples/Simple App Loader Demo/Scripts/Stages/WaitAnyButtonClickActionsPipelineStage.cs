using UnityEngine;
using UnityEngine.UI;

namespace BurningLab.ActionsPipeline.Samples.Simple_App_Loader_Demo.Scripts.Stages
{
    [AddTypeMenu("App Loader Demo/Wait Any Button Click Stage")]
    [System.Serializable]
    public class WaitAnyButtonClickActionsPipelineStage : ActionsPipelineStage
    {
        protected override void OnInit()
        {
            base.OnInit();

            Application.onBeforeRender += OnBeforeRenderEventHandler;
        }

        private void OnBeforeRenderEventHandler()
        {
            if (Input.anyKey)
            {
                Next(ActionsPipelineStageResult.Success);
            }
        }
        
        protected override void OnDeInit()
        {
            base.OnDeInit();

            Application.onBeforeRender -= OnBeforeRenderEventHandler;
        }
    }
}