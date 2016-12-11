using UnityEngine;
using System.Collections;

public class I_UIO : MonoBehaviour {

    [Tooltip("Little: ratio 0.3 // Middle: 0.5 // Large: 0.8 // Total: 1.0")]
    public AudioCircleSize audioCircleSize;
    protected float _radiusVolume;

    protected AudioSource _source;
    protected Vector2 _mousePosition2D;
    protected Vector2 _rectCenter;
    protected Vector2 _distance;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {

    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PROTECTED FUNCTIONS ///////////////////////////////////////
///////////////////////////////////////////////////////////////
    protected void Initialisation()
    {
        _source = transform.GetComponent<AudioSource>();
        _rectCenter.x = GetComponent<RectTransform>().position.x;
        _rectCenter.y = GetComponent<RectTransform>().position.y;

        switch (audioCircleSize)
        {
            case AudioCircleSize.Little:
                _radiusVolume = Constants.LITTLE_SIZE * Screen.height;
                break;
            case AudioCircleSize.Middle:
                _radiusVolume = Constants.MIDDLE_SIZE * Screen.height;
                break;
            case AudioCircleSize.Large:
                _radiusVolume = Constants.LARGE_SIZE * Screen.height;
                break;
            case AudioCircleSize.Total:
                _radiusVolume = Constants.TOTAL_SIZE * Screen.height;
                break;
        }
        Debug.Log(_radiusVolume);
    }
    /*********************************************************/

    protected void UpdateMousePosition() {
        _mousePosition2D.x = Input.mousePosition.x;
        _mousePosition2D.y = Input.mousePosition.y;
    }
    /*********************************************************/

    protected void CalculateDistance() {
        _distance.x = _rectCenter.x - _mousePosition2D.x;
        _distance.y = _rectCenter.y - _mousePosition2D.y;
    }
    /*********************************************************/
}
