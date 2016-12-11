using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource ambiantSource;
    public AudioSource securityLockSource;

    private bool _isSecurityLockPhase = false;

	// Use this for initialization
	void Start () {
        ambiantSource.volume = 1.0f;
        securityLockSource.volume = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
	    if (_isSecurityLockPhase && ambiantSource.volume == 1.0f) {
            // Tween ambianceSource.volume de 1 à 0
            // Tween securityLockSource.volume de 0 à 1
        }
        else if (!_isSecurityLockPhase && ambiantSource.volume == 0.0f) {
            // Tween ambianceSource.volume de 0 à 1
            // Tween securityLockSource.volume de 1 à 0
        }
    }

    public void activeSecurityLockPhase (bool a_bool = true) {
        _isSecurityLockPhase = a_bool;
    }
    public bool isSecurityLockPhase() {
        return _isSecurityLockPhase;
    }
}
