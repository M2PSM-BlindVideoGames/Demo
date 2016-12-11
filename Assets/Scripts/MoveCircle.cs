using UnityEngine;
using System.Collections;

public class MoveCircle : MonoBehaviour {

    public float speed = 0.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * speed);
        else if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector3.forward * speed);

        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.left * speed);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * speed);
    }
}
