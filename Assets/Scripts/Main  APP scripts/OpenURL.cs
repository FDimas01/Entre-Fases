using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    // Start is called before the first frame update
    public string Link;


    public void Openlink()
    {

        Application.OpenURL(Link);

    }
}
