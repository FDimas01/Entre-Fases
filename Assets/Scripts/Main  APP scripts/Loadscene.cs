using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Loadscene : MonoBehaviour
{

    [SerializeField] private string _scenetoLoad;

    private void Start()
    {
        checkUser();
    }

    private void OnDestroy()
    {
    }

    private void HandleAuthStateChanged(object sender, EventArgs e)
    {
        checkUser();
    }
    IEnumerator ExampleCoroutineT()
    {
        yield return new WaitForSeconds(3f);
    }

    private void checkUser()
    {
            StartCoroutine(ExampleCoroutineT());
            SceneManager.LoadScene(_scenetoLoad);
    }






}
