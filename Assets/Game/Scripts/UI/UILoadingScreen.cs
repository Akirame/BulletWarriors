using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UILoadingScreen : MonoBehaviour
{
    public Text loadingText;
    public Image loadingBar;    

    public void Update()
    {
        int loadingVal = (int)(LoaderManager.Get().loadingProgress * 100);        
        loadingText.text = "Loading " + loadingVal;
        loadingBar.fillAmount = loadingVal / 100;     
    }    
    public void SetVisible(bool show)
    {
        gameObject.SetActive(show);
    }
}