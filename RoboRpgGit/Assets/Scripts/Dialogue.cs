using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    
    MonoBehaviour[] letters;
    void Start()
    {

        
    }

   

    // Update is called once per frame
    void Update()
    {
      
    }

  
    
    /*
    public IEnumerator startFade(float delay, float rate)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(fade(rate));
    }

    public IEnumerator fade(float rate)
    {
        Color color = sprite.color;
        Color textColor = text.color;
        if ((color.a >= 0 || color.a <= 1) && finished)
        {
            color.a += rate;
            textColor.a += rate;
            sprite.color = color;
            text.color = textColor;

            yield return new WaitForSeconds(.2f);
            StartCoroutine(fade(rate));
        }
    }

    */
}
