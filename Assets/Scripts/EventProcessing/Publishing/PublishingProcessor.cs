using System.IO;
using Assets.Code.Gameplay;
using UnityEngine;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PublishingProcessor : MonoBehaviour
{
    public GameObject Title;
    public GameObject Description;
    public GameObject ImageFixedARParent;
    public GameObject Image;
    public GameObject ImageDescription;
    public GameObject Text;

    private PressEvent _event;
    private Choice _choice;


    void OnValidate()
    {
        Assert.IsNotNull(Title, name);
        Assert.IsNotNull(Title.GetComponent<Text>(), name);

        Assert.IsNotNull(Description, name);
        Assert.IsNotNull(Description.GetComponent<Text>(), name);

        Assert.IsNotNull(ImageFixedARParent, name);
        var child = ImageFixedARParent.transform.GetChild(0);
        Assert.IsNotNull(child, name);
        Assert.AreEqual(child.gameObject, Image, name);

        Assert.IsNotNull(Image, name);
        Assert.IsNotNull(Image.GetComponent<RawImage>(), name);
        Assert.IsNotNull(Image.GetComponent<AspectRatioFitter>(), name);

        Assert.IsNotNull(ImageDescription, name);
        Assert.IsNotNull(ImageDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(Text, name);
        Assert.IsNotNull(Text.GetComponent<Text>(), name);
    }


    public void Publish(PressEvent e, Choice choice)
    {
        _event = e;
        _choice = choice;

        Debug.Log("Start publishing multiple choice event: " + _event.Date + " choice: " + choice.Title);

        gameObject.SetActive(true);

        // Title and desc
        Title.GetComponent<Text>().text = choice.Title;
        Description.GetComponent<Text>().text = choice.Description;

        // Image
        bool isImage = choice.ImagePath != null;
        ImageFixedARParent.SetActive(isImage);
        ImageDescription.SetActive(isImage);

        if (isImage)
        {
            string path = Path.Combine(Constants.ArticleImagesResourceFolder, choice.ImagePath).Replace('\\', '/');
            Debug.Log("Loading a publishing image from: " + path);
            var texture = Resources.Load<Texture>(path);
            var image = Image.GetComponent<RawImage>();
            image.texture = texture;

            Image.GetComponent<AspectRatioFitter>().aspectRatio = texture.width / (float)texture.height;

            ImageDescription.GetComponent<Text>().text = choice.ImageLabel;
        }

        // Article text
        bool isArticleText = !string.IsNullOrEmpty(choice.ArticleText);
        Text.SetActive(isArticleText);

        if (isArticleText)
            Text.GetComponent<Text>().text = choice.ArticleText;
    }

    public void Finish()
    {
        Debug.Log("Finished publishing option " + _choice.Title);
        gameObject.SetActive(false);
        _event.Finish();
    }
}
