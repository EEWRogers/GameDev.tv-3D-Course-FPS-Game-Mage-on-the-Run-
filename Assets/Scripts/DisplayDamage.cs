using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image bloodSplatterImage;
    [SerializeField] float opacityDecayTime = 1f;
    float invisible = 0f;
    float fullyVisible = 1f;

     void Start() 
     {
        SetOpacity(invisible);
     }

    public void DisplayDamageIndicator()
    {
        StartCoroutine(EnableDamageIndicator());
    }

    void SetOpacity(float opacity)
    {
        Color colour = bloodSplatterImage.color;
        colour.a = opacity;
        bloodSplatterImage.color = colour;
    }

    IEnumerator EnableDamageIndicator()
    {
        float imageOpacity = fullyVisible;
        float percentDone = 0;

        SetOpacity(imageOpacity);

        while (imageOpacity > invisible)
        {
            yield return new WaitForEndOfFrame();

            imageOpacity = Mathf.Lerp(fullyVisible, invisible, percentDone);
            percentDone += Time.deltaTime / opacityDecayTime;
            SetOpacity(imageOpacity);
        }
        
    }
}
