using System;
using BurningLab.ActionsPipeline;
using UnityEngine;

public class AppLoader : MonoBehaviour
{
    [Tooltip("Application loading pipeline.")]
    [SerializeField] private ActionPipeline _loadingPipeline;

    public event Action<ActionPipelineStage> OnStageChanged;

    public float LoadingProgress => _loadingPipeline.Progress;
    
    // Start is called before the first frame update
    private void Start()
    {
        _loadingPipeline.OnPipelineStageStart += OnStageStartEventHandler;
        _loadingPipeline.RunPipeline();
    }

    [ContextMenu("Cancel Load")]
    public void CancelPipeline()
    {
        _loadingPipeline.Cancel();
    }
    
    private void OnDestroy()
    {
        _loadingPipeline.OnPipelineStageStart -= OnStageStartEventHandler;
    }

    private void OnStageStartEventHandler(ActionPipelineStage sender)
    {
        OnStageChanged?.Invoke(sender);
    }
}
