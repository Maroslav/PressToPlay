using UnityEngine;
using System.Collections.Generic;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Assets.Code.Gameplay;

public class MultipleChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choiceGameObjects = new List<Object>();

    public GameObject ToggledParent;
    public GameObject MultipleChoiceButtonPrefab;


    void OnValidate()
    {
        Assert.IsNotNull(ToggledParent);
        Assert.IsNotNull(MultipleChoiceButtonPrefab);
        Assert.IsNotNull(MultipleChoiceButtonPrefab.GetComponent<MultipleChoiceData>());
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        gameObject.transform.parent.gameObject.SetActive(true);

        RectTransform rt = (RectTransform)gameObject.transform;

        var choices = e.GetClosestOptions(Constants.DefaultChoicesCount);

        for (int i = 0; i < choices.Count; ++i)
        {
            GameObject choiceGameObject = Instantiate(MultipleChoiceButtonPrefab);
            choiceGameObject.transform.SetParent(transform, true);

            MultipleChoiceData multipleChoiceData = choiceGameObject.GetComponent<MultipleChoiceData>();
            multipleChoiceData.Choice = choices[i];
            multipleChoiceData.SetEvent(e, this);

            if (choiceGameObject.GetComponentsInChildren<Text>().Length > 0)
            {
                choiceGameObject.GetComponentsInChildren<Text>()[0].text = e.Choices[i].Description;
            }

            _choiceGameObjects.Add(choiceGameObject);
        }
    }

    public void DestroyChoices()
    {
        gameObject.transform.parent.gameObject.SetActive(false);

        foreach (Object choice in _choiceGameObjects)
        {
            Destroy(choice);
        }

        _choiceGameObjects.Clear();
    }
}
