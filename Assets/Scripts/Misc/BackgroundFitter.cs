using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AspectRatioFitter))]
public class BackgroundFitter : MonoBehaviour
{
    void Start()
    {
        var img = GetComponent<Image>();
        var fitter = GetComponent<AspectRatioFitter>();

        fitter.aspectRatio = img.mainTexture.width / (float)img.mainTexture.height;
    }
}
