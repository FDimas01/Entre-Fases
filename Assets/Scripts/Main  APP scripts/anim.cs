using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    public GameObject panel;    // Start is called before the first frame update
    public int Time;

    void OnEnable()
    {
    Animator animator = panel.GetComponent<Animator>();
    animator.SetBool("Upslide", false);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(Time);
    }

    public void ShowHideMenu()
    {

        if(panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("Upslide");
                animator.SetBool("Upslide", !isOpen);
                StartCoroutine(ExampleCoroutine());
            }



        }



    }



}
