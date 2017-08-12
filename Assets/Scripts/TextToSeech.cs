using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextToSeech : MonoBehaviour {

    // private varialbles
    [SerializeField]
    private string inputString;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    AudioSource source;
    private bool downloading = false;

    IEnumerator DownloadAudio()
    {
        downloading = true;
        WWW www = new WWW( "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q="+inputString+"&tl=En-gb");
        yield return www;
        source.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        if (source.clip != null) source.Play();
        downloading = false;
    }

    public void GetInput()
    {
        inputString = WWW.EscapeURL(inputField.text);
        if (downloading) return;
        StartCoroutine(DownloadAudio());
    }
}
