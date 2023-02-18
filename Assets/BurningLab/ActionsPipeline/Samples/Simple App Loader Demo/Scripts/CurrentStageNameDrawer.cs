using BurningLab.ActionsPipeline;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStageNameDrawer : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private Slider _slider;
    
    private AppLoader _appLoader;
    
    private void Start()
    {
        _appLoader = FindObjectOfType<AppLoader>();
        
        _appLoader.OnStageChanged += OnAppLoaderStageChangedEventHandler;
    }

    private void OnAppLoaderStageChangedEventHandler(ActionPipelineStage obj)
    {
        _titleText.SetText(obj.StageName);
        _slider.value = _appLoader.LoadingProgress;
    }
}
