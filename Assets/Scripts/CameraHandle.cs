using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    public float horizontalSpeed = 100.0f;
    public float verticalSpeed = 60.0f;

    private float tempEulerX;

    [SerializeField]
    private PlayerInput pi;

    [SerializeField]
    private GameObject cameraHandle;
    private GameObject playerHandle;


    // Start is called before the first frame update
    void Awake()
    {
        
        cameraHandle = transform.parent.gameObject;
        playerHandle = cameraHandle.transform.parent.gameObject;
        pi = playerHandle.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerHandle.transform.Rotate(Vector3.up, pi.JRight * horizontalSpeed*Time.deltaTime);

        tempEulerX  -= pi.JUp * verticalSpeed*Time.deltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -20, 30);
        cameraHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);
        //cameraHandle.transform.Rotate(Vector3.right, -pi.JUp * verticalSpeed*Time.deltaTime);
    }
}
