using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class UIZoomImage : MonoBehaviour
{
    public GameObject ImagePartograma;
    public static UIZoomImage UiZoom;
    float deltaDistance;
    float TouchZoomSpeed = 0.001f;
    private Vector3 MinZoom;
    private Vector3 MaxZoom;
    private Vector3 zoomChange;
    public GameObject camera;
 
    // Use this for initialization
    void Start()
    {
        UiZoom = this;
        MinZoom = new Vector3(1f, 1f, 1f);
        MaxZoom = new Vector3(3f, 3f, 3f);
    }
 
    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {
				// get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
				// get touch position from the previous frame
				Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
				Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;
 
				float oldTouchDistance = Vector2.Distance (tZeroPrevious, tOnePrevious);
				float currentTouchDistance = Vector2.Distance (tZero.position, tOne.position);
 
				// get offset value
				deltaDistance = oldTouchDistance - currentTouchDistance;
                zoomChange = new Vector3(-deltaDistance*TouchZoomSpeed,-deltaDistance*TouchZoomSpeed,0);
                Zoom();
            }
        }

        if (ImagePartograma.transform.position.x >= (400 + (transform.localScale.x * 200) - 200))
		{
         ImagePartograma.transform.position = new Vector3 ((400 + (transform.localScale.x * 200) - 200),ImagePartograma.transform.position.y,ImagePartograma.transform.position.z);
		}
        if (ImagePartograma.transform.position.x <= (-350 - (transform.localScale.x * 200) + 200))
		{
         ImagePartograma.transform.position = new Vector3 ((-350 - (transform.localScale.x * 200) + 200),ImagePartograma.transform.position.y,ImagePartograma.transform.position.z);
		}

        if (ImagePartograma.transform.position.y >= (0 + (transform.localScale.x * 250) - 250))
		{
         ImagePartograma.transform.position = new Vector3 (ImagePartograma.transform.position.x,(0 + (transform.localScale.x * 250) - 250),ImagePartograma.transform.position.z);
		}
        if (ImagePartograma.transform.position.y <= (-750 - (transform.localScale.x * 250) + 250))
		{
         ImagePartograma.transform.position = new Vector3 (ImagePartograma.transform.position.x,(-750 - (transform.localScale.x * 250) + 250),ImagePartograma.transform.position.z);
		}
        
        if(transform.localScale.x < 1)
        {
            ImagePartograma.transform.localScale = MinZoom;
        }
        if(transform.localScale.x > 3)
        {
            ImagePartograma.transform.localScale = MaxZoom;
        }

    }
 
    void Zoom()
    {
        ImagePartograma.transform.localScale += zoomChange;
    }
    public void rotacionarcamera()
    {
      Camera.main.transform.Rotate(0.0f, 0.0f, 90.0f);
      Camera.main.transform.position = new Vector3(0f, -370.0f, -10.0f);
      Camera.main.orthographicSize = 260;
    }
    public void retornarcamera()
    {
      Camera.main.transform.Rotate(0.0f, 0.0f, -90.0f);
      Camera.main.transform.position = new Vector3(0f, -600.0f, -10.0f);
      ImagePartograma.transform.position = new Vector3(0f, -600.0f, -3.0f);
      Camera.main.orthographicSize = 500;
      ImagePartograma.transform.localScale = MinZoom;
    }
}