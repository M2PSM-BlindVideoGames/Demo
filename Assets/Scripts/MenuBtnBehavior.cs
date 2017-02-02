using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuBtnBehavior : MonoBehaviour {

    private bool _isSoundLaunched;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    // Use this for initialization
    void Start () {
        _isSoundLaunched = false;
    }
    /*********************************************************/

    // Update is called once per frame
    void Update () {
        if (transform.parent.GetComponent<CanvasGroup>().alpha == 1 && GetComponent<Button>().interactable)
            UpdateMouseOnButton();
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void UpdateMouseOnButton() {
        bool mouseOnButton = RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition);
        if (mouseOnButton) {
            if(_isSoundLaunched == false) {
                GetComponents<AudioSource>()[0].Play();
                GetComponents<AudioSource>()[1].Play();
                _isSoundLaunched = true;
            }
        }
        else {
            _isSoundLaunched = false;
            GetComponents<AudioSource>()[0].Stop();
            GetComponents<AudioSource>()[1].Stop();
        }
    }
    /*********************************************************/
}
