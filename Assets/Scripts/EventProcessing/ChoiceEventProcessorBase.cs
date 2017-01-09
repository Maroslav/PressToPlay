using UnityEngine;
using System.Globalization;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Choices;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ChoiceEventProcessorBase<TChoiceEvent, TChoice> : MonoBehaviour
    where TChoiceEvent : ChoicePressEvent
    where TChoice : Choice
{
    public GameObject ChoiceName;
    public GameObject ChoiceDescription; 
    public GameObject ChoiceDate;

    public GameObject Publishing;

    public GameObject AudioPlayer;
    public AudioClip Clip;

    protected TChoiceEvent Event;


    protected virtual void OnValidate()
    {
        Assert.IsNotNull(ChoiceName, name);
        Assert.IsNotNull(ChoiceName.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceDescription, name);
        Assert.IsNotNull(ChoiceDescription.GetComponent<Text>(), name);

        Assert.IsNotNull(ChoiceDate, name);
        Assert.IsNotNull(ChoiceDate.GetComponent<Text>(), name);

        Assert.IsNotNull(Publishing, name);
        Assert.IsNotNull(Publishing.GetComponent<PublishingProcessor>(), name);

        Assert.IsNotNull(AudioPlayer, name);
        Assert.IsNotNull(AudioPlayer.GetComponent<AudioSource>(), name);
        Assert.IsNotNull(Clip, name);
    }


    public virtual void ProcessEvent(TChoiceEvent e)
    {
        Event = e;

        Debug.Log(string.Format("Processing a new {0} choice event: {1}", typeof(TChoiceEvent).Name, Event.Date));
        gameObject.SetActive(true);

        // Set event description in the UI
        ChoiceName.GetComponent<Text>().text = e.Name;
        ChoiceDescription.GetComponent<Text>().text = e.Description;
        ChoiceDate.GetComponent<Text>().text = e.Date.ToString("d", new CultureInfo("cs-CZ"));
    }

    internal virtual void ProcessChoice(TChoice choice)
    {
        Debug.Log(string.Format("{0} Choosing option {1}", typeof(TChoiceEvent).Name, choice.Title));
        gameObject.SetActive(false);

        // Play the typing sound
        var audioSource = AudioPlayer.GetComponent<AudioSource>();
        audioSource.PlayOneShot(Clip);

        // Let the event apply the changes to the world state
        Event.Apply(choice, WorldStateProvider.State);
        WorldStateProvider.UpdateAttributeGameObjects();
        // Let Publishing handle the rest (this component is now finished)
        Publishing.GetComponent<PublishingProcessor>().Publish(Event, choice);
    }
}
