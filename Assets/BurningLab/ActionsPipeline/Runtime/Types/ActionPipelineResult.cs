namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Actions pipeline complete result.
    /// </summary>
    public enum ActionPipelineResult
    {
        /// <summary>
        /// Action pipeline with successfully complete.
        /// </summary>
        Success = 0,
        
        /// <summary>
        /// Action pipeline complete with errors.
        /// </summary>
        Error = 1,
    }
}