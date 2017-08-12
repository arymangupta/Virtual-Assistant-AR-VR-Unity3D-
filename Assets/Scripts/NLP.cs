
using UnityEngine.UI;
using UnityEngine;

public class NLP {

    public string Process(string result , Image img)
    {
        result = result.ToLower();
        if(result.Contains("image")&& result.Contains("colour"))
        {
            if (result.Contains("red"))
            {
                img.GetComponent<Image>().color = Color.red;
                return "Color Set To Red";

            }
            else if (result.Contains("blue"))
            {
                img.GetComponent<Image>().color = Color.blue;
                return "Color Set To Green";
            }
            else if (result.Contains("cyan"))
            {
                img.GetComponent<Image>().color = Color.cyan;
                return "Color Set To Green";
            }
            else if (result.Contains("green"))
            {
                img.GetComponent<Image>().color = Color.green;
                return "Color Set To Green";
            }
        }
        return "Sorry Can't Get you..";
    }

	
}
