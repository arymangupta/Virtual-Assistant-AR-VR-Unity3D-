using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroiBookApiCall : MonoBehaviour {

    AndroidJavaClass apiClass;
    AndroidJavaObject instance;
    [SerializeField]
    Text outputText;
    [SerializeField]
    GameObject[] books;
    public GameObject moreDecription;

    void Start() { 


#if UNITY_EDITOR
        string s = "title#desc#https://screenshots.en.sftcdn.net/en/scrn/69660000/69660131/jpeg-to-pdf-02-535x535.png\ntitle#desc#https://screenshots.en.sftcdn.net/en/scrn/69660000/69660131/jpeg-to-pdf-02-535x535.png";
        BooksDisplay(s);
        return;
#endif
#if UNITY_ANDROID
        APIInit();
#endif
    }

     void APIInit()
    {
        apiClass = new AndroidJavaClass("com.api.request.Android_Async");
       
       
    }
    public void SendQuery(string query)
    {
        if (apiClass == null)
            APIInit();
        
        instance = apiClass.CallStatic<AndroidJavaObject>("start");
        instance.Call("Execute" , new object[] { query});
    }
    void CallBack(string output)
    {

        BooksDisplay(output);
        Debug.Log(output);
        outputText.text = output;
    }
     IEnumerator DownloadImage(string link , Image reference)
    {
        WWW www = new WWW(link);
        yield return www;
        reference.sprite =  Sprite.Create(www.texture, new Rect(0f, 0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));

    }
    void BooksDisplay(string output)
    {
        HideBooks(true); 
        string[] results = output.Split('\n');
        int l;
        if (books.Length < results.Length) l = books.Length;
        else l = results.Length;
        for (int i = 0; i < l; ++i)
        {
            string[] ans = results[i].Split('#');
            books[i].SetActive(true);
            books[i].GetComponent<Book>().myText.text =ans[1]; //ans[1]
            StartCoroutine(DownloadImage(ans[2] , books[i].GetComponent<Book>().myImage)); 
        }
    }
    void HideBooks(bool state)
    {
        for (int i = 0; i < books.Length; ++i)
        {
            books[i].SetActive(!state);
        }
    }
    public void ImageTap(Image myImage)
    {
        HideBooks(true);
        moreDecription.SetActive(true);
        moreDecription.GetComponentInChildren<Image>().sprite = myImage.sprite;
        moreDecription.GetComponentInChildren<Text>().text = myImage.gameObject.GetComponentInChildren<Text>().text;

    }


    public void HideDec()
    {
        HideBooks(false); // display
        moreDecription.SetActive(false);
    }
}
