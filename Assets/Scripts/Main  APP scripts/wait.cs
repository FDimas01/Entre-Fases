using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait : MonoBehaviour
{
    public int time;
    public int scenenumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scenenumber);
    }
}
