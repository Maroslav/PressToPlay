using System.Collections.Generic;
using System.Linq;
using Assets.Code.Gameplay;
using Assets.Code.GameState;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WorldStateProvider : MonoBehaviour
{
    public static WorldState State { get; private set; }

    private static Dictionary<Attrib, GameObject> attributeGOs = new Dictionary<Attrib, GameObject>();

    public GameObject AttributesGameObject;
    public GameObject CategoryPrefab;
    public GameObject AttributePrefab;


    private void OnValidate()
    {
        Assert.IsNotNull(AttributesGameObject, name);
        Assert.IsNotNull(CategoryPrefab, name);
        Assert.IsNotNull(AttributePrefab, name);
        Assert.IsNotNull(AttributePrefab.GetComponent<WorldAttributeChanger>(), name);
    }

    void Awake()
    {
        attributeGOs.Clear();
        DeserializeAttributes();

        // Create UI elements - Attribs
        foreach (var categoryPair in State.AllStates)
        {
            Debug.Log("Adding a new category: " + categoryPair.Key.Name);
            GameObject categoryGO = Instantiate(CategoryPrefab);
            categoryGO.transform.SetParent(AttributesGameObject.transform);

            bool anyVisible = false;
            foreach (var attributePair in categoryPair.Value.Where(a => a.Key.IsDisplayed))
            {
                GameObject attributeGO = Instantiate(AttributePrefab);
                attributeGO.transform.SetParent(categoryGO.transform);
                attributeGOs.Add(attributePair.Key, attributeGO);
                attributeGO.SetActive(true);

                GameObject filler = attributeGO.GetComponent<WorldAttributeChanger>().FillGameObject;
                filler.GetComponent<Image>().color = attributePair.Key.Color;

                anyVisible = true;
            }
            categoryGO.SetActive(anyVisible);
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

            attribChanger.DoChange(State.AllStates[attributePair.Key.Category][attributePair.Key], !doSetup);
        }
    }
}
