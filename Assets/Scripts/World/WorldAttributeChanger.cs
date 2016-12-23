using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WorldAttributeChanger : MonoBehaviour
{
    public GameObject DescriptionGameObject;
    public GameObject SliderGameObject;
    public GameObject PopupGameObject;

    public float AttributeValue;


    private void OnValidate()
    {
        Assert.IsNotNull(DescriptionGameObject, name);
        Assert.IsNotNull(DescriptionGameObject.GetComponent<Text>(), name);
        Assert.IsNotNull(SliderGameObject, name);
        Assert.IsNotNull(SliderGameObject.GetComponent<Slider>(), name);
        Assert.IsNotNull(SliderGameObject.GetComponent<SimpleTweener>(), name);
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

        var sliderTweener = SliderGameObject.GetComponent<SimpleTweener>();
        sliderTweener.Init(
            (minValue + maxValue) >> 1,
            val => s.value = val);

    }

    public void DoChange(int value, bool fancyAnims = false)
    {
        AttributeValue = value;

        if (!fancyAnims)
        {
            var s = SliderGameObject.GetComponent<Slider>();
            s.value = value;
            return;
        }

        var tweener = SliderGameObject.GetComponent<SimpleTweener>();
        tweener.TweenTo(value);

        //PopupGameObject.SetActive(true);
        //PopupGameObject.SetActive(false);
    }
}
