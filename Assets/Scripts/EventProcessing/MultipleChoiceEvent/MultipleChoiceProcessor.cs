using UnityEngine;
using System.Collections.Generic;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MultipleChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choiceGameObjects = new List<Object>();

    public GameObject MultipleChoiceButtonPrefab;


    void OnValidate()
    {
        Assert.IsNotNull(MultipleChoiceButtonPrefab);
        Assert.IsNotNull(MultipleChoiceButtonPrefab.GetComponent<MultipleChoiceData>());
    }

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        gameObject.transform.parent.gameObject.SetActive(true);

        RectTransform rt = (RectTransform)gameObject.transform;

        var choices = e.GetClosestOptions(3);
        float dx = rt.rect.width / choices.Count / 2;
        float dy = rt.rect.height / choices.Count / 2;


        for (int i = 0; i < choices.Count; ++i)
        {
            GameObject choiceGameObject = Instantiate(MultipleChoiceButtonPrefab);
            choiceGameObject.transform.SetParent(transform, true);
            choiceGameObject.transform.Translate(new Vector3(dx * (i * 2 + 1), rt.rect.height - dy * (i * 2 + 1), 0));

            MultipleChoiceData multipleChoiceData = choiceGameObject.GetComponent<MultipleChoiceData>();
            multipleChoiceData.Choice = choices[i];
            multipleChoiceData.SetEvent(e, this);
            //choice.transform.Translate(new Vector3(dx * (i * 2 + 1), 50 * i, 0));

            if (choiceGameObject.GetComponentsInChildren<Text>().Length > 0)
            {
                choiceGameObject.GetComponentsInChildren<Text>()[0].text = e.Choices[i].Description;
            }

            _choiceGameObjects.Add(choiceGameObject);
        }
        //viewer.GetComponent<EventViewerChoicesList>().choices = choices;
        //GameObject btn = (GameObject)GameObject.Instantiate(myHeadLineButton);
        //TODO: Process event.
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
