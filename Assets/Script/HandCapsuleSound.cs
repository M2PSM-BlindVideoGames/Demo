using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Add this script to HandCapsule object
// HandCapsule object has to have 2 AudioSource component
public class HandCapsuleSound : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;
    private List<Transform> bones3List;
    private int _nbFingerIn;

    [Header("Constant Source")]
    public AudioClip constBadSound;
    public AudioClip constGoodSound;
    private AudioSource _constantSource;
    [Header("Finger Source")]
    public AudioClip fingerInSound;
    public AudioClip fingerOutSound;
    private AudioSource _fingerSource;

    private bool _allFingersIn;
    private bool _test = false;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        _constantSource = GetComponents<AudioSource>()[0];
        _fingerSource = GetComponents<AudioSource>()[1];

        _nbFingerIn = 0;

        BuildBones3List();
        _test = true;
    }
    /*********************************************************/

    void Update () {
        UpdateConstantSound();
    }
    /*********************************************************/

    void OnTriggerExit(Collider a_finger) {
        if (_test) {
            // Check if collider a_finger is a part of a LeapMotion's finger
            if (a_finger.transform.parent.gameObject.GetComponent("RigidFinger")) {
                // Consider only one bone per finger
                if (a_finger.name == "bone3") {
                    _nbFingerIn--;
                    Debug.Log("Out : " + a_finger.transform.parent.name);
                    Debug.Log(_nbFingerIn);
                    _fingerSource.clip = fingerOutSound;
                    _fingerSource.Play();
                }
            }    
        }
    }
    /*********************************************************/

    void OnTriggerEnter(Collider a_finger) {
        // Check if collider a_finger is a part of a LeapMotion's finger
        if (a_finger.transform.parent.gameObject.GetComponent("RigidFinger")) {
            // Consider only one bone per finger
            if (a_finger.name == "bone3") {
                _nbFingerIn++;
                Debug.Log("In : " + a_finger.transform.parent.name);
                Debug.Log(_nbFingerIn);
                _fingerSource.clip = fingerInSound;
                _fingerSource.Play();
            }
        }
    }
    /*********************************************************/

    ///////////////////////////////////////////////////////////////
    /// PRIVATE FUNCTIONS /////////////////////////////////////////
    ///////////////////////////////////////////////////////////////
    // bones3List :
    // [0]Thumb left, [1]Thumb right, [2]index left, [3]index right, ...
    void BuildBones3List() {
        bones3List = new List<Transform>();

        Transform currentFinger;
        Transform currentBone3;
        
        for (int i = 0; i < 5; i++) {
            // Left
            currentFinger = leftHand.GetChild(i);
            currentBone3 = currentFinger.GetChild(2);
            bones3List.Add(currentBone3);
            // Right
            currentFinger = rightHand.GetChild(i);
            currentBone3 = currentFinger.GetChild(2);
            bones3List.Add(currentBone3);
        }
    }
    /*********************************************************/

    void UpdateConstantSound() {
        _allFingersIn = (_nbFingerIn == 10);

       if (_allFingersIn == false) {
            _constantSource.clip = constBadSound;
            _constantSource.volume = (float)(10 - _nbFingerIn) / 10;
        } else {
            _constantSource.clip = constGoodSound;
            _constantSource.volume = 1.0f;
        }

        if (!_constantSource.isPlaying)
            _constantSource.Play();
    }
    /*********************************************************/
}
