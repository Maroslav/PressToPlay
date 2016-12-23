using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WorldAttributeChanger : MonoBehaviour
{
    // The undisputed value of the attribute that this script represents
    public float AttributeValue;

    public GameObject DescriptionGameObject;
    public GameObject SliderGameObject;
    public GameObject PopupGameObject;


    private void OnValidate()
    {
        Assert.IsNotNull(DescriptionGameObject, name);
        Assert.IsNotNull(DescriptionGameObject.GetComponent<Text>(), name);
        Assert.IsNotNull(SliderGameObject, name);
        Assert.IsNotNull(SliderGameObject.GetComponent<Slider>(), name);
        Assert.IsNotNull(SliderGameObject.GetComponent<FloatTweener>(), name);
        Assert.IsNotNull(PopupGameObject, name);
        Assert.IsNotNull(PopupGameObject.GetComponent<Text>(), name);
        Assert.IsNotNull(PopupGameObject.GetComponent<Vector3Tweener>(), name);
    }

    void Start()
    {
        PopupGameObject.SetActive(false);
    }


    public void DoSetup(string description, int minValue, int maxValue)
    {
        // Desc
        Text desc = DescriptionGameObject.GetComponent<Text>();
        desc.text = description;

        // Slider
        Slider s = SliderGameObject.GetComponent<Slider>();
        s.minValue = minValue;
        s.maxValue = maxValue;

        var sliderTweener = SliderGameObject.GetComponent<FloatTweener>();
        sliderTweener.Init(
            (minValue + maxValue) >> 1,
            val => s.value = val, // 3. keep changing slider value
            abrupt =>
            {
                if (!abrupt)
                    PopupGameObject.SetActive(false);
                // Assert showing the correct value
                s.value = AttributeValue;
            }); // 4. hide the popup
    }

    public void DoChange(int value, bool fancyAnims = false)
    {
        float diff = value - AttributeValue;

        // Update popup
        var popupText = PopupGameObject.GetComponent<Text>();
        popupText.text = string.Format("{0}{1}", diff > 0 ? "+" : string.Empty, diff);

        // Save the new value AFTER
        AttributeValue = value;

        if (!fancyAnims)
        {
            var s = SliderGameObject.GetComponent<Slider>();
            s.value = value;
            return;
        }

        if (Math.Abs(diff) < 0.001f)
            return;

        // Start the tweening action
        PopupGameObject.SetActive(true);
        PopupGameObject.transform.localScale = Vector3.one;

        var popupTweener = PopupGameObject.GetComponent<Vector3Tweener>();

        // Re-init the tweener to update the finish function
        popupTweener.Init(
            PopupGameObject.transform.localScale,
            val => PopupGameObject.transform.localScale = val, // 1. keep chaning popup scale
            abrupt => StartSliderTween()); // 2. start slider tween

        popupTweener.TweenTo(new Vector3(2, 2, 2));
    }

    private void StartSliderTween()
    {
        var sliderTweener = SliderGameObject.GetComponent<FloatTweener>();
        sliderTweener.TweenTo(AttributeValue); // Use the current value as the target
    }
}
