using UnityEngine;

public class UIO_SecurityLock : I_UIO {
    private float _winRadius/* = 0.05f*/;
    private bool _isDoorUnlocked;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start() {
        _isDoorUnlocked = false;
        float ratio = 800 / Screen.width * 600 / Screen.height;
        Debug.Log(ratio);
        _winRadius = transform.GetComponent<RectTransform>().rect.height / 2 /** Screen.width / Screen.height*/;
        Debug.Log(Screen.height+ " / " + Screen.width + " = " + Screen.height / Screen.width);
        Debug.Log("#################### " + _winRadius);
        Initialisation();
    }
    /*********************************************************/

    void Update() {
        UpdateMousePosition();
        CalculateDistance();

        _source.volume = 0.0f;

        if (_distance.magnitude < _radiusVolume) {
            _source.volume = Mathf.Pow((_radiusVolume - _distance.magnitude) / _radiusVolume, 3);
            CheckWinRadius();
        }
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void CheckWinRadius() {
        Debug.Log(_distance.magnitude);
        if (_distance.magnitude < _winRadius) {
            _isDoorUnlocked = true;
        }
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PUBLIC FUNCTIONS //////////////////////////////////////////
///////////////////////////////////////////////////////////////
    public bool IsDoorUnlocked() { return _isDoorUnlocked; }
    /*********************************************************/
}
