﻿using System.Collections.Generic;
using Assets.Code.Gameplay;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

class ImageChoiceProcessor : MonoBehaviour
{
    private readonly List<Object> _choiceGameObjects = new List<Object>();

    public GameObject ImageChoiceButtonPrefab;


    void OnValidate()
    {
        Assert.IsNotNull(ImageChoiceButtonPrefab);
        Assert.IsNotNull(ImageChoiceButtonPrefab.GetComponent<ImageChoiceData>());
    }


    public void ProcessEvent(ImageChoiceEvent e, ImageChoiceEventProcessor eventManager)
    {
        var choices = e.Choices;

        foreach (ImageChoice c in choices)
        {
            GameObject choiceGameObject = Instantiate(ImageChoiceButtonPrefab);
            choiceGameObject.transform.SetParent(transform, true);

            ImageChoiceData imageChoiceData = choiceGameObject.GetComponent<ImageChoiceData>();
            imageChoiceData.SetEvent(c, eventManager);

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
