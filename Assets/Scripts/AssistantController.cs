using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class AssistantController : MonoBehaviour {

    private Rigidbody rb;
    private Animation anim;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.S))
        {
            obj.SetActive(true);
        }
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 velocity = new Vector3(x, 0, y);
        rb.velocity = velocity * 4f;

        if (x != 0 || y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x*0, Mathf.Atan2(x, y) * Mathf.Rad2Deg,transform.eulerAngles.z*0);
        }
        if (x != 0 || y != 0)
        {
            anim.Play("walk");
        }
        else anim.Play("idle");
    }

    public void ScaleUp()
    {
        float temp = transform.localScale.y;
        temp+=0.3f;
            transform.localScale = Vector3.one * temp;
    }
    public void ScaleDown()
    {
        float temp = transform.localScale.y;
        if (temp > 0.3f)
        {
            temp -= 0.3f;
            transform.localScale = Vector3.one * temp;
        }
    }
}
