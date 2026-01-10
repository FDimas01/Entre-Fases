using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject startscreen;
    public GameObject main;
    public GameObject user;

    public void StartApp(){
        startscreen.SetActive(true);
        main.SetActive(false);
        user.SetActive(false);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    
}
