using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine;

public class SlidersManager : MonoBehaviour
{
    public ControlPanel controlPanel;
    public SliderBehavior minThresholdSlider;
    public SliderBehavior maxThresholdSlider;

    void Start()
    {
        if (minThresholdSlider == null || maxThresholdSlider == null)
        {
            Debug.LogError("SlidersManager: One or both SliderBehavior references are not set");
            return;
        }
        if (controlPanel == null)
        {
            Debug.LogError("SlidersManager: ControlPanel reference is not set");
            return;
        }
    }


    /// <summary>
    /// Notify slider change to the other slider, the controlled value, and update the value accordingly
    /// </summary>
    public void Notify(SliderBehavior sender, float value)
    {
        if (sender == null || value < 0f)
        {
            Debug.LogError("Sender is null in Notify method of SlidersManager or value is negative");
            return;
        }
        if (sender == minThresholdSlider)
        {
            if (value > maxThresholdSlider.GetValue())
            {
                maxThresholdSlider.SetValue(value);
            }
            // Notify to the ControlPanel about the change
            Debug.Log($"Min Threshold Slider changed to {value}");
        }
        else if (sender == maxThresholdSlider)
        {
            if (value < minThresholdSlider.GetValue())
            {
                minThresholdSlider.SetValue(value);
            }
            // Notify to the ControlPanel about the change
            Debug.Log($"Max Threshold Slider changed to {value}");
        }
        else
        {
            Debug.LogWarning("Sender slider is not recognized by SlidersManager");
        }
            
    }
}
