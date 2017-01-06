using UnityEngine;
using System.Collections.Generic;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Assets.Code.Gameplay;

public class MultipleChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choiceGameObjects = new List<Object>();
  
    public GameObject MultipleChoiceButtonPrefab;


    void OnValidate()
    {
        Assert.IsNotNull(MultipleChoiceButtonPrefab);
        Assert.IsNotNull(MultipleChoiceButtonPrefab.GetComponent<MultipleChoiceData>());
    }



    public void ProcessEvent(MultipleChoiceEvent e, MultipleChoiceEventProcessor eventManager)
    {
        var choices = e.GetClosestOptions(Constants.DefaultChoicesCount);

        for (int i = 0; i < choices.Count; ++i)
        {
            GameObject choiceGameObject = Instantiate(MultipleChoiceButtonPrefab);
            choiceGameObject.transform.SetParent(transform, true);

            MultipleChoiceData multipleChoiceData = choiceGameObject.GetComponent<MultipleChoiceData>();
            multipleChoiceData.Choice = choices[i];
            multipleChoiceData.SetEvent(e, eventManager);

            if (choiceGameObject.GetComponentsInChildren<Text>().Length > 0)
            {
                choiceGameObject.GetComponentsInChildren<Text>()[0].text = e.Choices[i].ChoiceText;
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
