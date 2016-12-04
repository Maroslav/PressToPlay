using UnityEngine;
using System.Collections.Generic;
using Assets.Code.PressEvents;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MultipleChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choices = new List<Object>();

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

        int pocet = 3; // e.Options.Count
        float dx = rt.rect.width / pocet / 2;
        float dy = rt.rect.height / pocet / 2;

        for (int i = 0; i < pocet; ++i)
        {
            GameObject choice = Instantiate(MultipleChoiceButtonPrefab);
            choice.transform.SetParent(transform, true);
            choice.transform.Translate(new Vector3(dx * (i * 2 + 1), rt.rect.height - dy * (i * 2 + 1), 0));

            MultipleChoiceData multipleChoiceData = choice.GetComponent<MultipleChoiceData>();
            multipleChoiceData.ChoiceIndex = i;
            multipleChoiceData.SetEvent(e, this);
            //choice.transform.Translate(new Vector3(dx * (i * 2 + 1), 50 * i, 0));

            if (choice.GetComponentsInChildren<Text>().Length > 0)
            {
                choice.GetComponentsInChildren<Text>()[0].text = e.Choices[i].Description;
            }

            _choices.Add(choice);
        }
        //viewer.GetComponent<EventViewerChoicesList>().choices = choices;
        //GameObject btn = (GameObject)GameObject.Instantiate(myHeadLineButton);
        //TODO: Process event.
    }

    public void DestroyChoices()
    {
        gameObject.transform.parent.gameObject.SetActive(false);

        foreach (Object choice in _choices)
        {
            Destroy(choice);
        }

        _choices.Clear();
    }
}
