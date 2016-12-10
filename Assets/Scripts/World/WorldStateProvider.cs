using System;
using System.Collections.Generic;
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

    void Start()
    {
        DeserializeAttributes();

        // Create UI elements - Attribs
        foreach (var attributePair in State.JournalistState)
        {
            GameObject attributeGO = Instantiate(WorldAttributePrefab);
            attributeGO.transform.SetParent(WorldAttributesGameObject.transform);
            attributeGOs.Add(attributePair.Key, attributeGO);
        }

        UpdateAttributeGameObjects(true);
    }

    private void DeserializeAttributes()
    {
        State = new WorldState();
        State.JournalistState[Attribs.Credibility] = Attribs.MidValue;
        // TODO: Different creation/deserialization
    }


    public static void UpdateAttributeGameObjects(bool doSetup = false)
    {
        foreach (var attributePair in attributeGOs)
        {
            var attribChanger = attributePair.Value.GetComponent<WorldAttributeChanger>();

            if (doSetup)
                attribChanger.DoSetup(attributePair.Key.Description, Attribs.MinValue, Attribs.MaxValue);

            attribChanger.DoChange(State.JournalistState[attributePair.Key]);
        }
    }
}
