using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.PressEvents;
using UnityEngine.UI;

public class PressEventViewProcessor : MonoBehaviour {
    private List<GameObject> choices = new List<GameObject>();

    public void ProcessEvent(MultipleChoiceEvent e)
    {
        GameObject viewer = GameObject.Find("EventViewer");
        RectTransform rt = (RectTransform)viewer.transform;
        //GameObject.Instantiate(HeadlineButton, viewer.transform);
        //GameObject btn = (GameObject)GameObject.Instantiate(Resources.Load("HeadLineButton"));

        int pocet = 3; // e.Options.Count
        float dx = rt.rect.width / pocet / 2;
        float dy = rt.rect.height / pocet / 2;
        for (int i = 0; i < pocet; ++i)
        {
            GameObject choice = (GameObject)GameObject.Instantiate(Resources.Load("HeadLineButton"), viewer.transform);
            choice.transform.Translate(new Vector3(dx * (i * 2 + 1), rt.rect.height - dy * (i * 2 + 1), 0));
            choice.GetComponent<ChoiceData>().choiceIndex = i;
            choice.GetComponent<ChoiceData>().setEvent(e);
            //choice.transform.Translate(new Vector3(dx * (i * 2 + 1), 50 * i, 0));
            if (choice.GetComponentsInChildren<Text>().Length > 0)
            {
                choice.GetComponentsInChildren<Text>()[0].text = e.Options[i].Description;
            }
            choices.Add(choice);
        }
        //viewer.GetComponent<EventViewerChoicesList>().choices = choices;
        //GameObject btn = (GameObject)GameObject.Instantiate(myHeadLineButton);
        //TODO: Process event.
    }
    public void DestroyChoices()
    {
        foreach (GameObject choice in choices)
        {
            GameObject.Destroy(choice);
        }
    }
}
