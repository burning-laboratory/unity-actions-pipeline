namespace BurningLab.ActionsPipeline.Stages
{
    /// <summary>
    /// Set parent class ActionPipelineStage for any your custom actions pipeline stages.
    ///
    /// Be sure to add the Serializable attribute.
    ///
    /// If you need to specify your own path to an action in Type Menu, you can do this using the Add Type Menu attribute.
    /// </summary>
    [System.Serializable]
    [AddTypeMenu("RootFolderName/SubFolderName/Custom Action Name")]
    public class SimpleStage : ActionPipelineStage
    {
        protected override void OnInit()
        {
            base.OnInit();
            
            // Write preparing code for action running here.
        }

        protected override void OnDeInit()
        {
            base.OnDeInit();
            
            // Write the code that will be executed after the completion of the action step.
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            // Write custom action logic here.
        }
    }
}