using UnityEngine;
using System.Collections;

public class UIO_MouseListener : MonoBehaviour {

    private Vector3 _mousePosition3D;

    // Use this for initialization
    void Start () {
        _mousePosition3D.z = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        _mousePosition3D.x = Input.mousePosition.x;
        _mousePosition3D.y = Input.mousePosition.y;

        transform.position = _mousePosition3D;
    }
}
