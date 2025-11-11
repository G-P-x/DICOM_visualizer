using UnityEngine;
using UnityEngine.UI;
using UnityVolumeRendering;

public class ControlPanel : MonoBehaviour
{
    Slider minThresholdSlider;
    Slider maxThresholdSlider;
    Button DynamicVolumeRenderingButton;
    Button IsosurfaceRenderingButton;
    Button MaximumIntensityProjectionButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // Called when the volume is loaded and VolumeRendering is active in the scene
    /// <summary>
    /// Sets up the ControlPanel allowing to change the VolumeRenderedObject attributes from the ControlPanel.
    /// </summary>
    /// <param name="volumeObject">the loaded VolumeRenderedObject</param>
    public void SetControlPanelControls(VolumeRenderedObject volumeObject)
    {
        
    }
}
