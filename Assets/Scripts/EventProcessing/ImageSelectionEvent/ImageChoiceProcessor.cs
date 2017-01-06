using System.Collections.Generic;
using Assets.Code.Gameplay;
using Assets.Code.PressEvents;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

class ImageChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choiceGameObjects = new List<Object>();

    public GameObject ToggledParent;
    public GameObject ImageChoiceButtonPrefab;

    void OnValidate()
    {
        Assert.IsNotNull(ToggledParent);
        Assert.IsNotNull(ImageChoiceButtonPrefab);
        Assert.IsNotNull(ImageChoiceButtonPrefab.GetComponent<ImageChoiceData>());
    }

    public void ProcessEvent(ImageChoiceEvent e, ImageChoiceEventProcessor eventManager)
    {
        //var choices = e.GetClosestOptions(Constants.DefaultChoicesCount);
        var choices = e.Choices;

        for (int i = 0; i < choices.Count; ++i)
        {
            GameObject choiceGameObject = Instantiate(ImageChoiceButtonPrefab);
            choiceGameObject.transform.SetParent(transform, true);

            ImageChoiceData imageChoiceData = choiceGameObject.GetComponent<ImageChoiceData>();
            imageChoiceData.Choice = choices[i];
            imageChoiceData.SetEvent(e, eventManager);

            if (choiceGameObject.GetComponentsInChildren<Text>().Length > 0)
            {
                //choiceGameObject.GetComponentsInChildren<Text>()[0].text = e.Choices[i].Title;
            }

            _choiceGameObjects.Add(choiceGameObject);
        }
    }

    public void DestroyChoices()
    {
        foreach (Object choice in _choiceGameObjects)
        {
            Destroy(choice);
        }

        _choiceGameObjects.Clear();
    }
}
