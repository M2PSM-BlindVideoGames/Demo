using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Add this script to HandCapsule object
// WARNING : HandCapsule object has to have 2 AudioSource component
// WARNING : in the hand pool script of LeapMotionController the two bool "Can Duplicate" need to be false (or you would have some bug when clones will be created).
public class HandCapsuleSound : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;
    private List<Transform> bones3InCapsuleList;                         // Contains list of bone3's finger which are on the capsule

    [Header("Constant Source")]
    public AudioClip constBadSound;
    public AudioClip constGoodSound;
    private AudioSource _constantSource;
    [Header("Finger Source")]
    public AudioClip fingerInSound;
    public AudioClip fingerOutSound;
    private AudioSource _fingerSource;

    private bool _allFingersIn;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        _constantSource = GetComponents<AudioSource>()[0];
        _fingerSource = GetComponents<AudioSource>()[1];
        
        bones3InCapsuleList = new List<Transform>();
    }
    /*********************************************************/

    void Update () {
        UpdateConstantSound();
    }
    /*********************************************************/

    void OnTriggerExit(Collider a_finger) {
        // Check if collider a_finger is a part of a LeapMotion's finger
        if (a_finger.transform.parent.gameObject.GetComponent("RigidFinger"))
        {
            // Consider only one bone per finger
            if (a_finger.name == "bone3")
            {
                // Check if the bone3 exists in the bones3InCapsuleList to remove it
                if (bones3InCapsuleList.Contains(a_finger.transform)) {
                    Debug.Log("Remove");
                    bones3InCapsuleList.Remove(a_finger.transform);
                    Debug.Log(bones3InCapsuleList.Count);
                    Debug.Log("Out : " + a_finger.transform.parent.name + " / " + a_finger.transform.parent.parent.name);
                    _fingerSource.clip = fingerOutSound;
                    _fingerSource.Play();
                } else  {
                    Debug.Log("Don't exist");
                }
            }
        } 
    }
    /*********************************************************/

    void OnTriggerEnter(Collider a_finger) {
        // Check if collider a_finger is a part of a LeapMotion's finger
        if (a_finger.transform.parent.gameObject.GetComponent("RigidFinger"))
        {
            // Consider only one bone per finger
            if (a_finger.name == "bone3")
            {
                // Check if the bone3 is already contained in the bones3InCapsuleList before adding it
                if (bones3InCapsuleList.Contains(a_finger.transform)) {
                    Debug.Log("Exist already");
                } else {
                    Debug.Log("Add");
                    bones3InCapsuleList.Add(a_finger.transform);
                    Debug.Log(bones3InCapsuleList.Count);
                    Debug.Log("In : " + a_finger.transform.parent.name + " / " + a_finger.transform.parent.parent.name);
                    _fingerSource.clip = fingerInSound;
                    _fingerSource.Play();
                }
            }
        }
    }
    /*********************************************************/

    ///////////////////////////////////////////////////////////////
    /// PRIVATE FUNCTIONS /////////////////////////////////////////
    ///////////////////////////////////////////////////////////////
    void UpdateConstantSound() {
        _allFingersIn = (bones3InCapsuleList.Count == 10);

       if (_allFingersIn == false) {
            _constantSource.clip = constBadSound;
            _constantSource.volume = (float)(10 - bones3InCapsuleList.Count) / 10;
        } else {
            _constantSource.clip = constGoodSound;
            _constantSource.volume = 1.0f;
        }

        if (!_constantSource.isPlaying)
            _constantSource.Play();
    }
    /*********************************************************/
}
