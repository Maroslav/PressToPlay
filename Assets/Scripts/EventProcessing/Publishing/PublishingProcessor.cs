using System.IO;
using UnityEngine;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PublishingProcessor : MonoBehaviour
{
    public GameObject Title;
    public GameObject Description;
    public GameObject Image;
    public GameObject ImageDescription;
    public GameObject Text;


    public string ResourceFolder = "/Cutscenes";
    private PressEvent _event;
    private Choice _choice;


    void OnValidate()
    {
        Assert.IsNotNull(Title, name);
        Assert.IsNotNull(Title.GetComponent<Text>(), name);

        Assert.IsNotNull(Description, name);
        Assert.IsNotNull(Description.GetComponent<Text>(), name);

        Assert.IsNotNull(Image, name);
        Assert.IsNotNull(Image.GetComponent<RawImage>(), name);

        Assert.IsNotNull(ImageDescription, name);
        Assert.IsNotNull(ImageDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(Text, name);
        Assert.IsNotNull(Text.GetComponent<Text>(), name);
    }


    public void Publish(PressEvent e, TextChoice choice)
    {
        _event = e;
        _choice = choice;

        Debug.Log("Start publishing multiple choice event: " + _event.Date + " choice: " + choice.Title);

        gameObject.SetActive(true);

        Title.GetComponent<Text>().text = choice.Title;
        Description.GetComponent<Text>().text = choice.Description;

        if (choice.ImagePath != null)
        {
            Image.SetActive(true);
            ImageDescription.SetActive(true);

            string path = Path.Combine(ResourceFolder, choice.ImagePath).Replace('\\', '/');
            Debug.Log("Loading a publishing image from: " + path);
            var texture = Resources.Load<Texture>(path);
            var image = Image.GetComponent<RawImage>();
            image.texture = texture;
            GetComponent<AspectRatioFitter>().aspectRatio = texture.width / (float)texture.height;

            ImageDescription.GetComponent<Text>().text = ""; // TODO!!
        }
        else
        {
            Image.SetActive(false);
            ImageDescription.SetActive(false);
        }

        Text.GetComponent<Text>().text = choice.ArticleText;
    }

    public void Publish(PressEvent e, ImageChoice choice)
    {
        Debug.Log("Start publishing image event: " + _event.Date + " choice: " + choice.Title);
        // TODO
    }

    public void Finish()
    {
        Debug.Log("Finished publishing option " + _choice.Title);
        gameObject.SetActive(false);
        _event.Finish();
    }
}
