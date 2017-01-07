using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class ImageInnerButton : MonoBehaviour
{

    public GameObject ButtonContainer;

    void OnValidate()
    {
        Assert.IsNotNull(ButtonContainer);
        Assert.IsNotNull(ButtonContainer.GetComponent<ImageChoiceData>());
    }

    public void OnClick()
    {
        Debug.Log("ImageInnerButton.OnClick");
        ButtonContainer.GetComponent<ImageChoiceData>().OnClick();
    }
}
