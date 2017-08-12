
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest : MonoBehaviour {
    AndroidJavaClass unityBridgeClassReference;
    AndroidJavaObject unityActivityReferene;

    public AndroiBookApiCall api;

    public Image displayImg;
    public Text text;

    private NLP nlp = new NLP();

    void GetSpeechText(string output)
    {
        text.text = output;
        output = output.ToLower();
        if (output.Contains("find") || output.Contains("search"))
        {
            api.SendQuery(output); // API Call
        }
        else
        {
            nlp.Process(output, displayImg); // Inbuilt 
        }
    }
    // called from button
    public void SpeechRec()
    {
        if (unityActivityReferene == null && unityBridgeClassReference == null)
        {
            unityBridgeClassReference = new AndroidJavaClass("com.speech.myplugin.UnityBridge");
            unityActivityReferene = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        }
        unityBridgeClassReference.CallStatic("SwitchActivity", unityActivityReferene);
    }
}
