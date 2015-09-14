using UnityEngine;
using System.Collections;

public class MarkerMovement : MonoBehaviour {

    public int currentPosition;

    private void Awake()
    {
        currentPosition = 0;
    }

	public void OneDown()
    {
        if (currentPosition == 0)
        {
            //Debug.Log("Position: " + GetComponent<RectTransform>().rect.position);
            //GetComponent<RectTransform>().rect.Set(0, 230, 1, 1);
            Debug.Log("Position:" + GetComponent<RectTransform>().localPosition);
        }
    }

    public void OneUp()
    {

    }
}