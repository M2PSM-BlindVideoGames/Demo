using UnityEngine;
using System.Collections;

public class MenuBtnBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMouseOnButton();
    }

    void UpdateMouseOnButton() {
        bool mouseOnButton = RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition);
        if (mouseOnButton) {
            GetComponents<AudioSource>()[0].Play();
            GetComponents<AudioSource>()[1].Play();
        }
        else {
            GetComponents<AudioSource>()[0].Stop();
            GetComponents<AudioSource>()[1].Stop();
        }
    }
}
