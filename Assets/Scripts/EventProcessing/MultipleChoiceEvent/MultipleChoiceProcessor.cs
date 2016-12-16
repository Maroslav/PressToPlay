using UnityEngine;
using System.Collections.Generic;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Assets.Code.Gameplay;

public class MultipleChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choiceGameObjects = new List<Object>();
    private bool _isShowingSelectedChoice = false;
    public bool CanFinishEvent { get; private set; }
    private MultipleChoiceEvent _event;

    public GameObject ToggledParent;
    public GameObject MultipleChoiceButtonPrefab;


    void OnValidate()
    {
        Assert.IsNotNull(ToggledParent);
        Assert.IsNotNull(MultipleChoiceButtonPrefab);
        Assert.IsNotNull(MultipleChoiceButtonPrefab.GetComponent<MultipleChoiceData>());
    }

    internal void MoveToNextState(DecisionChoice choice)
    {
        if (_isShowingSelectedChoice)
        {
            DestroySelectedChoiceDescription();
            _isShowingSelectedChoice = false;
            CanFinishEvent = true;
        }
        else
        {
            DestroyChoices();
            ShowSelectedChoiceDescription(choice);
            _isShowingSelectedChoice = true;
        }
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        _event = e;
        CanFinishEvent = false;
        gameObject.transform.parent.gameObject.SetActive(true);

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
                choiceGameObject.GetComponentsInChildren<Text>()[0].text = e.Choices[i].Title;
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

    public void ShowSelectedChoiceDescription(DecisionChoice choice)
    {
        GameObject choiceGameObject = Instantiate(MultipleChoiceButtonPrefab);
        choiceGameObject.transform.SetParent(transform, true);

        MultipleChoiceData multipleChoiceData = choiceGameObject.GetComponent<MultipleChoiceData>();
        multipleChoiceData.Choice = choice;
        multipleChoiceData.SetEvent(_event, this);

        Text[] textComps = choiceGameObject.GetComponentsInChildren<Text>();

        if (textComps.Length > 0)
        {
            Text text = textComps[0];
            text.text = choice.Description;
        }
        _choiceGameObjects.Add(choiceGameObject);
    }

    public void DestroySelectedChoiceDescription()
    {
        gameObject.transform.parent.gameObject.SetActive(false);

        DestroyChoices();
    }
}
