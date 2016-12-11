using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour {

    public float speed = 1.0f;

    private AudioSource source;

    private bool _isWalking;

	// Use this for initialization
	void Start () {
        source = transform.GetComponent<AudioSource>();
        _isWalking = false;
    }
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        PlayStepMusic();
    }

    void MovePlayer() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * speed);
            _isWalking = true;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.back * speed);
            _isWalking = true;
        } else {
            _isWalking = false;
        }
    }

    void PlayStepMusic() {
        if (_isWalking && !source.isPlaying) {
            source.Play();
        } else if (!_isWalking){
            source.Pause();
        }
    }
}
