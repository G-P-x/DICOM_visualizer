using UnityEngine.UI;
using UnityEngine;

public enum SliderType
{
    MIN_VALUE,
    MAX_VALUE
}

public class SliderBehavior : MonoBehaviour
{
    [SerializeField]
    private SliderType sliderType = SliderType.MIN_VALUE;
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
        if (sliderType == SliderType.MIN_VALUE)
        {
            slider.minValue = 0f;
            slider.maxValue = 1f;
            slider.value = 0f; // Initialize to minimum
        }
        else if (sliderType == SliderType.MAX_VALUE)
        {
            slider.minValue = 0f;
            slider.maxValue = 1f;
            slider.value = 1f; // Initialize to maximum
        }
    }

    // Actions taken when the slider value changes
    private void NotifyManager()
    {
        if (manager != null)
        {
            manager.Notify(sliderType, (float)slider.value);
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