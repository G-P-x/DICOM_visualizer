using UnityEngine.UI;
using UnityEngine;

public class SliderBehavior : MonoBehaviour
{
    public SlidersManager manager; // Reference to the SlidersManager
    public Slider slider; // Reference to the Slider component

    void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
        if (manager == null)
        {
            Debug.LogError("SlidersManager reference is not set in SliderBehavior");
        }
        slider.onValueChanged.AddListener(delegate { NotifyManager(); ChangeColor(); });
    }

    // Actions taken when the slider value changes
    private void NotifyManager()
    {
        if (manager != null)
        {
            manager.Notify(this, (float)slider.value);
        }
        return;
    }
    private void ChangeColor()
    {
        // Example method to change the color of the slider based on its value
        Image fill = slider.fillRect.GetComponent<Image>();
        if (fill != null)
        {
            if (slider.value < slider.maxValue / 2)
            {
                fill.color = Color.green;
            }
            else
            {
                fill.color = Color.red;
            }
        }
        return;
    }

    // Getter and Setter for slider value
    public void SetValue(float value)
    {
        slider.value = value;
        Debug.Log($"Slider value set to {value}");
        return;
    }

    public float GetValue()
    {
        return slider.value;
    }
}