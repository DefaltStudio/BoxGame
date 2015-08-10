using UnityEngine;
using System.Collections;

public class tmp_RotationTest : MonoBehaviour {

    #region Variables
    public float turnSmoothing = 2f;
    private Quaternion targetRotation;
    #endregion

    void Start()
    {
        targetRotation = GetComponent<Rigidbody>().rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetRotation.eulerAngles += new Vector3(0f, 90f, 0f);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MoveRotation(Quaternion.Lerp(
            GetComponent<Rigidbody>().rotation, targetRotation, Time.deltaTime * turnSmoothing));
    }
}
