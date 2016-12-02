using UnityEngine;
using System.Collections;

public class OnClickHandler : MonoBehaviour {

    public void HandleChoiceSelection ()
    {
        GetComponent<ChoiceData>().ChooseOption();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
