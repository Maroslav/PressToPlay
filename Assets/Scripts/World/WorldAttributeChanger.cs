using Assets.Code.GameState;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WorldAttributeChanger : MonoBehaviour
{
    public GameObject DescriptionGameObject;
    public GameObject SliderGameObject;


    private void OnValidate()
    {
        Assert.IsNotNull(DescriptionGameObject, name);
        Assert.IsNotNull(DescriptionGameObject.GetComponent<Text>(), name);
        Assert.IsNotNull(SliderGameObject, name);
        Assert.IsNotNull(SliderGameObject.GetComponent<Slider>(), name);
    }


    public void DoSetup(string description, int minValue, int maxValue)
    {
        Text desc = DescriptionGameObject.GetComponent<Text>();
        desc.text = description;

        Slider s = SliderGameObject.GetComponent<Slider>();
        s.minValue = minValue;
        s.maxValue = maxValue;
    }

    public void DoChange(int value)
    {
        Slider s = SliderGameObject.GetComponent<Slider>();
        s.value = value;
    }
}
