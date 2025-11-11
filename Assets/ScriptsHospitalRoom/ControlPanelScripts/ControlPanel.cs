using UnityEngine;
using UnityEngine.UI;
using UnityVolumeRendering;

public class ControlPanel : MonoBehaviour
{
    [Tooltip("Linker is VolumeObjControlPanelLinker that connects ControlPanel with VolumeRenderedObject")]
    public VolumeObjControlPanelLinker linker;

    /// <summary>
    /// Notify render mode change to the linked VolumeRenderedObject
    /// </summary>
    /// <param name="mode"></param>
    public void NotifyRenderModeChange(UnityVolumeRendering.RenderMode mode)
    {
        Debug.Log($"ControlPanel: Render mode changed to {mode}");
        linker.NotifyRenderModeChange(mode);
    }
    
    /// <summary>
    /// Notify threshold changes to the linked VolumeRenderedObject
    /// </summary>
    /// <param name="minThreshold">Threshold from minimum slider</param>
    /// <param name="maxThreshold">Threshold from maximum slider</param>
    public void NotifyThresholdChange(float minThreshold, float maxThreshold)
    {
        Debug.Log($"ControlPanel: Thresholds changed to Min: {minThreshold}, Max: {maxThreshold}");
        linker.NotifyThresholdChange(minThreshold, maxThreshold);
    }
}
