using System;
using BurningLab.ActionsPipeline;
using UnityEngine;

public class AppLoader : MonoBehaviour
{
    [Tooltip("Application loading pipeline.")]
    [SerializeField] private ActionPipeline _loadingPipeline;

    public event Action<ActionsPipelineStage> OnStageChanged;

    public float LoadingProgress => _loadingPipeline.Progress;
    
    // Start is called before the first frame update
    private void Start()
    {
        _loadingPipeline.OnPipelineStageStart += OnStageStartEventHandler;
        _loadingPipeline.RunPipeline();
    }
    
    private void OnDestroy()
    {
        _loadingPipeline.OnPipelineStageStart -= OnStageStartEventHandler;
    }

    private void OnStageStartEventHandler(ActionsPipelineStage sender)
    {
        OnStageChanged?.Invoke(sender);
    }
}
