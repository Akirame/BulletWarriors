using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UILoadingScreen : MonoBehaviour
{
    public Image loadingBar;

    public void Update()
    {
        int loadingVal = (int)(LoaderManager.Get().loadingProgress * 100);
        loadingBar.fillAmount = (float)loadingVal / 100;
    }    
    public void SetVisible(bool show)
    {
        gameObject.SetActive(show);
    }
}