using System.Collections;
using UnityEngine;



[System.Serializable]
public abstract class UI : MonoBehaviour
{   
    protected CanvasGroup canvasGroup{get;set; }
    protected Animator animator { get;set;}

    public abstract void Awake();
    public abstract IEnumerator Display();
    public abstract IEnumerator Hide();   
}
