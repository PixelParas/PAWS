using UnityEngine;

public class ResizableUI : MonoBehaviour
{

    public RectTransform rt;
    public RectTransform rtPL;
    public RectTransform rtPR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rtPR.sizeDelta = new Vector2(rtPL.sizeDelta.x, 100);
    }

    public void Change()
    {

    }
}
