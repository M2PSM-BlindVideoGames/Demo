using UnityEngine;

public class UIO_Disturb : I_UIO {

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        Initialisation();
    }
    /*********************************************************/

    void Update () {
        UpdateMousePosition();
        CalculateDistance();

        _source.volume = 0.0f;

        if (_distance.magnitude < _radiusVolume) {
            _source.volume = (_radiusVolume - _distance.magnitude) / _radiusVolume;
        }
    }
    /*********************************************************/
}
