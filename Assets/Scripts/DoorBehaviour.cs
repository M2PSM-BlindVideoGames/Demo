using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

    public GameObject player;
    private bool _isDoorActived = false;
    private BoxCollider _collider;

	// Use this for initialization
	void Start () {
        _collider = transform.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void collider(Collider a_otherColl)
    {
        // Si a_otherCollider == player.collider
        // Si bouton d'activation appuyé
        // Activation phase de securityLock
    }
}
