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
        Assert.IsNull(State);
        State = new WorldState();

        State.JournalistState.AddAttribute(Attribs.Credibility, Attribs.MidValue);
        // TODO: Different creation/deserialization

        Debug.Log("Attribs to fill: " + State.JournalistState.Values.Count);

        // Create UI elements - Attribs
        foreach (var attributePair in State.JournalistState.Values)
        {
            GameObject attributeGO = Instantiate(WorldAttributePrefab);
            attributeGO.transform.SetParent(WorldAttributesGameObject.transform);

            attributeGOs.Add(attributePair.Key, attributeGO);
        }

        UpdateAttributeGameObjects(true);
    }


    public static void UpdateAttributeGameObjects(bool doSetup = false)
    {
        foreach (var attributePair in attributeGOs)
        {
            Debug.Log("Filling " + attributePair.Key.Description);
            var attribChanger = attributePair.Value.GetComponent<WorldAttributeChanger>();

            if (doSetup)
                attribChanger.DoSetup(attributePair.Key.Description, Attribs.MinValue, Attribs.MaxValue);

            attribChanger.DoChange(State.JournalistState.Values[attributePair.Key]);
        }
    }
}
