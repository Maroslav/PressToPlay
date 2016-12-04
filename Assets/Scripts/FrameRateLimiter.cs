using UnityEngine;
using System.Collections;

public class FrameRateLimiter : MonoBehaviour
{
    public int FrameRate = 60;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(ChangeFramerate());
    }

    IEnumerator ChangeFramerate()
    {
        yield return new WaitForSeconds(1);
        Debug.Log(string.Format("Setting frame rate cap to {0} fps.", FrameRate));
        Application.targetFrameRate = FrameRate;
    }
}
