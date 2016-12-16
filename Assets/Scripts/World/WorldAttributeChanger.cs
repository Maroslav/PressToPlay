using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WorldAttributeChanger : MonoBehaviour
{
    public GameObject DescriptionGameObject;

    public GameObject SliderGameObject;
    public float SlideAnimationSpeedCoef = 1;

    public GameObject PopupGameObject;
    private const float PopupAnimationLenght = 3.5f;
    public float PopupAnimationSpeedCoef = 1;


    private void OnValidate()
    {
        Assert.IsNotNull(DescriptionGameObject, name);
        Assert.IsNotNull(DescriptionGameObject.GetComponent<Text>(), name);
        Assert.IsNotNull(SliderGameObject, name);
        Assert.IsNotNull(SliderGameObject.GetComponent<Slider>(), name);
        Assert.IsNotNull(PopupGameObject, name);
        Assert.IsNotNull(PopupGameObject.GetComponent<Text>(), name);
    }


    public void DoSetup(string description, int minValue, int maxValue)
    {
        Text desc = DescriptionGameObject.GetComponent<Text>();
        desc.text = description;

        Slider s = SliderGameObject.GetComponent<Slider>();
        s.minValue = minValue;
        s.maxValue = maxValue;
    }

    public void DoChange(int value, bool fancyAnims = false)
    {
        if (!fancyAnims)
        {
            var s = SliderGameObject.GetComponent<Slider>();
            s.value = value;
            return;
        }





        // TODO: log time !!!



        var popupHash = iTween.Hash(
            "name", "AttributePopupTween_" + gameObject.name,
            "from", Vector3.one * 2,
            "to", Vector3.one,
            "time", PopupAnimationLenght * PopupAnimationSpeedCoef,
            "easetype", iTween.EaseType.easeOutElastic,
            "onupdate", "OnPopupTweenUpdate",
            "oncomplete", "OnPopupTweenComplete",
            "oncompleteparams", value);
        iTween.ValueTo(gameObject, popupHash);
        PopupGameObject.SetActive(true);
    }

    void OnPopupTweenUpdate(Vector3 newValue)
    {
        var p = PopupGameObject.GetComponent<Text>();
        p.transform.localScale = newValue;
    }

    void OnPopupTweenComplete(float newValue)
    {
        Debug.Log("Popup complete");
        Slider s = SliderGameObject.GetComponent<Slider>();

        var sliderHash = iTween.Hash(
            "name", "AttributeSliderTween_" + gameObject.name,
            "from", s.value,
            "to", newValue,
            "time", 10 * (newValue - s.value) / s.maxValue * SlideAnimationSpeedCoef,
            "easetype", iTween.EaseType.easeOutBack,
            "onupdate", "OnSliderTweenUpdate",
            "oncomplete", "OnSliderTweenComplete");
        iTween.ValueTo(gameObject, sliderHash);
    }

    void OnSliderTweenUpdate(float newValue)
    {
        var s = SliderGameObject.GetComponent<Slider>();
        s.value = newValue;
    }

    void OnSliderTweenComplete()
    {
        Debug.Log("Slide complete");
        PopupGameObject.SetActive(false);
    }
}
