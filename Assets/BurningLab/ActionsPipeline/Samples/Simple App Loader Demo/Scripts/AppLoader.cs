using BurningLab.ActionsPipeline;
using UnityEngine;

public class AppLoader : MonoBehaviour
{
    [SerializeField] private ActionsPipeline _loadingPipeline;
    
    // Start is called before the first frame update
    void Start()
    {
        _loadingPipeline.RunPipeline();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
