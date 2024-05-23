namespace BurningLab.ActionsPipeline
{
    /// <summary>
    /// Stage compete results.
    /// </summary>
    public enum ActionsPipelineStageResult
    {
        /// <summary>
        /// Stage successfully complete.
        /// </summary>
        Success = 0,
        
        /// <summary>
        /// Stage not complete. Contain errors.
        /// </summary>
        Error = 1,
        
        /// <summary>
        /// Stage skipped.
        /// </summary>
        Skipped = 2,
        
        /// <summary>
        /// Action pipeline is cancelled.
        /// </summary>
        Cancelled = 3
    }
}