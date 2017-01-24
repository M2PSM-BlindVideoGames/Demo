using UnityEngine;
using System.Collections;

public class LP_Movements : MonoBehaviour {

    //public float initializationHandThreshold = 1.0f;

    [Header("Gauche")]
    public GameObject L_hand;
    GameObject[] L_fingers;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    Vector3[] L_fingersPos;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    //Vector3[] L_fingersInitialPos;      //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring

    [Header("Droite")]
    public GameObject R_hand;
    GameObject[] R_fingers;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    Vector3[] R_fingersPos;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    //Vector3[] R_fingersInitialPos;      //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring

    bool _isForwardMvtChecked;
    public bool IsForwardMvtChecked() { return _isForwardMvtChecked; }
    bool _isBackMvtChecked;
    public bool IsBackMvtChecked() { return _isBackMvtChecked; }
    bool _isRightMvtChecked;
    public bool IsRightMvtChecked() { return _isRightMvtChecked; }
    bool _isLeftMvtChecked;
    public bool IsLeftMvtChecked() { return _isLeftMvtChecked; }

    bool _isMenuOpen;
    public void SetIsMenuOpen(bool a_bool) { _isMenuOpen = a_bool; }
    public bool IsMenuOpen() { return _isMenuOpen; }
    bool _isOpenMenuChecked;
    public void ResetOpenMenu() { _isOpenMenuChecked = false; }
    public bool IsOpenMenuChecked() { return _isOpenMenuChecked; }
    bool _isCloseMenuChecked;
    public void ResetCloseMenu() { _isCloseMenuChecked = false; }
    public bool IsCloseMenuChecked() { return _isCloseMenuChecked; }

    bool _isYesMvtChecked;
    public bool IsYesMvtChecked() { return _isYesMvtChecked; }
    bool _isNoMvtChecked;
    public bool IsNoMvtChecked() { return _isNoMvtChecked; }

    float _sliderValue;
    public float GetSliderValue() { return _sliderValue; }

    ///////////////////////////////////////////////////////////////
    /// GENERAL FUNCTIONS /////////////////////////////////////////
    ///////////////////////////////////////////////////////////////
    void Start () {
        InitializeFingers();
	}
    /*********************************************************/
	
	void Update () {
        if(L_hand.activeSelf && R_hand.activeSelf) {
            CheckForwardMovement();
            CheckBackMovement();
            CheckRightMovement();
            CheckLeftMovement();

            CheckOpenMenu();
            CheckCloseMenu();
            CheckYes();
            CheckNo();
        }
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void InitializeFingers() {
        L_fingers = new GameObject[5];
        R_fingers = new GameObject[5];

        for (int i = 0; i < L_fingers.Length; i++) {
            L_fingers[i] = L_hand.transform.GetChild(i).GetChild(2).gameObject;         // bone3
        }

        for(int i = 0; i < R_fingers.Length; i++) {
            R_fingers[i] = R_hand.transform.GetChild(i).GetChild(2).gameObject;         // bone3
        }
    }
    /*********************************************************/

    /*void CheckInitializationPositions() {
        // AudioInstruction : veuillez positionner vos mains au dessus du LeapMotion, gardez la pose.
        // Wait 0.5 seconds
        // First positions
        Vector3[] temp_R_fingersPos = new Vector3[5];
        Vector3[] temp_L_fingersPos = new Vector3[5];
        for (int i = 0; i < R_fingers.Length; i++) {
            temp_R_fingersPos[i] = R_fingers[i].transform.position;
            temp_L_fingersPos[i] = L_fingers[i].transform.position;
        }

        // Wait 2 seconds
        // Second positions
        R_fingersInitialPos = new Vector3[5];
        L_fingersInitialPos = new Vector3[5];
        for (int i = 0; i < R_fingersInitialPos.Length; i++) {
            R_fingersInitialPos[i] = R_fingers[i].transform.position;
            L_fingersInitialPos[i] = L_fingers[i].transform.position;
        }

        // Distance between first and second positions.
        Vector3[] distances_R = new Vector3[5];
        Vector3[] distances_L = new Vector3[5];
        for (int i = 0; i < distances_R.Length; i++) {
            distances_R[i] = CalculDistance(temp_R_fingersPos[i], R_fingersInitialPos[i]);
            distances_L[i] = CalculDistance(temp_L_fingersPos[i], L_fingersInitialPos[i]);
        }

        // Compare distance with a threshold
        bool isInitializationOkay = true;
        for (int i = 0; i < distances_R.Length; i++) {
            isInitializationOkay = isInitializationOkay && (distances_R[i].magnitude < initializationHandThreshold) && (distances_L[i].magnitude < initializationHandThreshold);
        }
    }
    /*********************************************************/

    void CheckForwardMovement() {
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index

        Vector3 distanceRFingers = CalculDistance(R_fingersPos[0], R_fingersPos[1]);
        Vector3 distanceLFingers = CalculDistance(L_fingersPos[0], L_fingersPos[1]);
        Vector3 distanceRLFingers = CalculDistance(R_fingersPos[0], L_fingersPos[1]);

        Debug.Log(distanceRFingers + " - " + distanceRFingers + " - " + distanceRLFingers);
        bool movementChecked = false;
        _isForwardMvtChecked = movementChecked;
    }
    /*********************************************************/

    void CheckBackMovement() {
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index

        Vector3 distanceRFingers = CalculDistance(R_fingersPos[0], R_fingersPos[1]);
        Vector3 distanceLFingers = CalculDistance(L_fingersPos[0], L_fingersPos[1]);
        Vector3 distanceRLFingers = CalculDistance(R_fingersPos[1], L_fingersPos[0]);

        Debug.Log(distanceRFingers + " - " + distanceRFingers + " - " + distanceRLFingers);
        bool movementChecked = false;
        _isBackMvtChecked = movementChecked;
    }
    /*********************************************************/

    void CheckRightMovement() {
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index

        Vector3 distanceRFingers = CalculDistance(R_fingersPos[0], R_fingersPos[1]);
        Vector3 distanceLFingers = CalculDistance(L_fingersPos[0], L_fingersPos[1]);
        Vector3 distanceRLThumbs = CalculDistance(R_fingersPos[0], L_fingersPos[0]);
        Vector3 distanceRLIndexs = CalculDistance(R_fingersPos[1], L_fingersPos[1]);

        Debug.Log(distanceRFingers + " - " + distanceRFingers + " - " + distanceRLThumbs + " - " + distanceRLIndexs);
        bool movementChecked = false;
        _isRightMvtChecked = movementChecked;
    }
    /*********************************************************/

    void CheckLeftMovement() {
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index

        Vector3 distanceRFingers = CalculDistance(R_fingersPos[0], R_fingersPos[1]);
        Vector3 distanceLFingers = CalculDistance(L_fingersPos[0], L_fingersPos[1]);
        Vector3 distanceRLThumbs = CalculDistance(R_fingersPos[0], L_fingersPos[0]);
        Vector3 distanceRLIndexs = CalculDistance(R_fingersPos[1], L_fingersPos[1]);

        Debug.Log(distanceRFingers + " - " + distanceRFingers + " - " + distanceRLThumbs + " - " + distanceRLIndexs);
        bool movementChecked = false;
        _isLeftMvtChecked = movementChecked;
    }
    /*********************************************************/
    
    void CheckOpenMenu() {
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index

        Vector3 distanceThumbs = CalculDistance(R_fingersPos[0], L_fingersPos[0]);
        Debug.Log(distanceThumbs);
        bool movementChecked = false;
        _isOpenMenuChecked = movementChecked;
    }
    /*********************************************************/
    void CheckCloseMenu() {
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index

        Vector3 distanceThumbs = CalculDistance(R_fingersPos[0], L_fingersPos[0]);
        Debug.Log(distanceThumbs);
        bool movementChecked = false;
        _isCloseMenuChecked = movementChecked;
    }
    /*********************************************************/
    void CheckYes() {
        L_fingersPos[0] = L_fingers[0].transform.position;  // L_thumb
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index

        Vector3 distanceLFingers = CalculDistance(L_fingersPos[0], L_fingersPos[1]);
        Debug.Log(distanceLFingers);
        bool movementChecked = false;
        _isYesMvtChecked = movementChecked;
    }
    /*********************************************************/
    void CheckNo() {
        R_fingersPos[0] = R_fingers[0].transform.position;  // R_thumb
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index

        Vector3 distanceRFingers = CalculDistance(R_fingersPos[0], R_fingersPos[1]);
        Debug.Log(distanceRFingers);
        bool movementChecked = false;
        _isNoMvtChecked = movementChecked;
    }
    /*********************************************************/

    void SliderValue() {
        R_fingersPos[1] = R_fingers[1].transform.position;  // R_index
        L_fingersPos[1] = L_fingers[1].transform.position;  // L_index

        _sliderValue = CalculDistance(R_fingersPos[1], L_fingersPos[1]).magnitude / 100.0f;
        if (_sliderValue <= 0.0f)
            _sliderValue = 0.0f;
        if (_sliderValue >= 1.0f)
            _sliderValue = 1.0f;
    }
    /*********************************************************/

    Vector3 CalculDistance(Vector3 a_vec1, Vector3 a_vec2) {
        Vector3 distance = new Vector3();
        distance.x = a_vec1.x - a_vec2.x;
        distance.y = a_vec1.y - a_vec2.y;
        distance.z = a_vec1.z - a_vec2.z;
        return distance;
    }
    /*********************************************************/
}
