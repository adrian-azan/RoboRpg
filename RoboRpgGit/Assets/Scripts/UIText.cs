using UnityEngine;


using TMPro;

public class UIText : MonoBehaviour
{
    private TextMeshPro tmp;
    private string _text { get;set; }

    public void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    public void Update()
    {
       
    }

}
