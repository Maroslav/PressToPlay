using System;
using System.Collections.Generic;
using Assets.Code.Gameplay;
using Assets.Code.GameState;
using UnityEngine;
using UnityEngine.Assertions;

public class WorldStateProvider : MonoBehaviour
{
    public static WorldState State { get; private set; }

    private static Dictionary<Attrib, GameObject> attributeGOs = new Dictionary<Attrib, GameObject>();

    public GameObject WorldAttributesGameObject;
    public GameObject WorldAttributePrefab;


    private void OnValidate()
    {
        Assert.IsNotNull(WorldAttributesGameObject, name);
        Assert.IsNotNull(WorldAttributePrefab, name);
        Assert.IsNotNull(WorldAttributePrefab.GetComponent<WorldAttributeChanger>(), name);
    }

    void Awake()
    {
        attributeGOs.Clear();
        DeserializeAttributes();

        // Create UI elements - Attribs
        foreach (var attributePair in State.JournalistState)
        {
            GameObject attributeGO = Instantiate(WorldAttributePrefab);
            attributeGO.transform.SetParent(WorldAttributesGameObject.transform);
            attributeGOs.Add(attributePair.Key, attributeGO);
            attributeGO.SetActive(true);
        }

        UpdateAttributeGameObjects(true);
    }

    private void DeserializeAttributes()
    {
        State = GameInit.CreateWorldState(Constants.AttributesDefinitionLoc);
    }


    public static void UpdateAttributeGameObjects(bool doSetup = false)
    {
        foreach (var attributePair in attributeGOs)
        {
            var attribChanger = attributePair.Value.GetComponent<WorldAttributeChanger>();

            if (doSetup)
                attribChanger.DoSetup(attributePair.Key.Description, Attribs.MinValue, Attribs.MaxValue);

            attribChanger.DoChange(State.JournalistState[attributePair.Key], !doSetup);
        }
    }
}
