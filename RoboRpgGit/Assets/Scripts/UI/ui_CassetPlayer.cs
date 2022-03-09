
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


[System.Serializable]
public class ui_CassetPlayer : UI
{
    private TMP_Text text {get;set; }
   
    public override void  Awake()
    {
        animator = GetComponentInChildren<Animator>(true);
        text = GetComponentInChildren<TMP_Text>(true);
        canvasGroup = GetComponentInChildren<CanvasGroup>(true);
        canvasGroup.alpha = 1;
    }

    public bool isShown()
    {
        return animator.GetBool("Show");
    }

    public void SetText(string name)
    {
        text.text = name;
    }

    public override IEnumerator Display()
    {
        var currentState = animator.GetBool("Show");
       animator.SetBool("Show",!currentState);

       yield return new WaitForEndOfFrame();
    }

    public override IEnumerator Hide()
    {
        animator.SetBool("Show",false);
  
        yield return new WaitForEndOfFrame();
    }
}