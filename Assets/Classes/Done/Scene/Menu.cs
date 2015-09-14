using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    private void Update()
    {
        MarkerMovement marker = new MarkerMovement();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            marker.OneDown();
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(Input.mousePosition);
        Debug.Log("Mouse is " + screenPos.x + " pixels from the left");

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.Log("Mouse over: " + hit.collider.tag);
        //}
    }
}
