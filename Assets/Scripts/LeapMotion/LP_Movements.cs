using UnityEngine;
using System.Collections;

public class LP_Movements : MonoBehaviour {

    [Header("Gauche")]
    public GameObject indexG;
    public GameObject thumbG;
    public GameObject L_hand;
    GameObject[] L_fingers;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    GameObject L_thumb;
    GameObject L_index;
    GameObject L_middle;
    GameObject L_pinky;
    GameObject L_ring;
    Vector3[] L_fingersPos;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    Vector3 L_thumbPos;
    Vector3 L_indexPos;
    Vector3 L_middlePos;
    Vector3 L_pinkyPos;
    Vector3 L_ringPos;

    Vector3[] L_fingersInitialPos;      //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    Vector3 L_thumbInitialPos;
    Vector3 L_indexInitialPos;
    Vector3 L_middleInitialPos;
    Vector3 L_pinkyInitialPos;
    Vector3 L_ringInitialPos;

    [Header("Droite")]
    public GameObject indexD;
    public GameObject thumbD;
    public GameObject R_hand;
    GameObject[] R_fingers;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    GameObject R_thumb;
    GameObject R_index;
    GameObject R_middle;
    GameObject R_pinky;
    GameObject R_ring;
    Vector3[] R_fingersPos;             //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    Vector3 R_thumbPos;
    Vector3 R_indexPos;
    Vector3 R_middlePos;
    Vector3 R_pinkyPos;
    Vector3 R_ringPos;

    Vector3[] R_fingersInitialPos;      //0: thumb, 1: index, 2: middle, 3: pinky, 4: ring
    Vector3 R_thumbInitialPos;
    Vector3 R_indexInitialPos;
    Vector3 R_middleInitialPos;
    Vector3 R_pinkyInitialPos;
    Vector3 R_ringInitialPos;

    private Vector3 indexPosG;
    private Vector3 thumbPosG;
    private Vector3 indexPosD;
    private Vector3 thumbPosD;
    
///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        InitializeFingers();
	}
    /*********************************************************/
	
	void Update () {
        CheckMovementOne();
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
        /*L_thumb = L_hand.transform.GetChild(0).GetChild(2).gameObject;
        L_index = L_hand.transform.GetChild(1).GetChild(2).gameObject;
        L_middle = L_hand.transform.GetChild(2).GetChild(2).gameObject;
        L_pinky = L_hand.transform.GetChild(3).GetChild(2).gameObject;
        L_ring = L_hand.transform.GetChild(4).GetChild(2).gameObject;*/

        for(int i = 0; i < R_fingers.Length; i++) {
            R_fingers[i] = R_hand.transform.GetChild(i).GetChild(2).gameObject;         // bone3
        }
        /*R_thumb = R_hand.transform.GetChild(0).GetChild(2).gameObject;
        R_index = R_hand.transform.GetChild(1).GetChild(2).gameObject;
        R_middle = R_hand.transform.GetChild(2).GetChild(2).gameObject;
        R_pinky = R_hand.transform.GetChild(3).GetChild(2).gameObject;
        R_ring = R_hand.transform.GetChild(4).GetChild(2).gameObject;*/
    }
    /*********************************************************/

    void CheckInitializationPositions() {
        // AudioInstruction : veuillez positionner vos mains au dessus du LeapMotion, gardez la pose.
        // Wait 0.5 seconds
        Vector3[] temp_R_fingersPos = new Vector3[5];
        for(int i = 0; i < R_fingers.Length; i++) {
            temp_R_fingersPos[i] = R_fingers[i].transform.position; 
        }
        
        Vector3[] temp_L_fingersPos = new Vector3[5];
        for(int i = 0; i < L_fingers.Length; i++) {
            temp_L_fingersPos[i] = L_fingers[i].transform.position;
        }
        /*Vector3 temp_R_thumbPos = R_thumb.transform.position;
        Vector3 temp_R_indexPos = R_index.transform.position;
        Vector3 temp_R_middlePos = R_middle.transform.position;
        Vector3 temp_R_pinkyPos = R_pinky.transform.position;
        Vector3 temp_R_ringPos = R_ring.transform.position;

        Vector3 temp_L_thumbPos = L_thumb.transform.position;
        Vector3 temp_L_indexPos = L_index.transform.position;
        Vector3 temp_L_middlePos = L_middle.transform.position;
        Vector3 temp_L_pinkyPos = L_pinky.transform.position;
        Vector3 temp_L_ringPos = L_ring.transform.position;*/

        // Wait 2 seconds
        R_fingersInitialPos = new Vector3[5];
        for(int i = 0; i < R_fingersInitialPos.Length; i++) {
            R_fingersInitialPos[i] = R_fingers[i].transform.position;
        }
        /*R_thumbInitialPos = R_thumb.transform.position;
        R_indexInitialPos = R_index.transform.position;
        R_middleInitialPos = R_middle.transform.position;
        R_pinkyInitialPos = R_pinky.transform.position;
        R_ringInitialPos = R_ring.transform.position;*/
        L_fingersInitialPos = new Vector3[5];
        for(int i = 0; i < L_fingersInitialPos.Length; i++) {
            L_fingersInitialPos[i] = L_fingers[i].transform.position;
        }
        /*L_thumbInitialPos = L_thumb.transform.position;
        L_indexInitialPos = L_index.transform.position;
        R_middleInitialPos = L_middle.transform.position;
        R_pinkyInitialPos = L_pinky.transform.position;
        R_ringInitialPos = L_ring.transform.position;*/

        Vector3[] distances_R = new Vector3[5];
        for(int i = 0; i < L_fingersInitialPos.Length; i++) {
            distances_R[i] = CalculDistance(temp_L_fingersPos[i], R_fingersInitialPos[i]);
        }
        //Vector3 distance_RThumb = CalculDistance(temp_R_thumbPos, R_thumbInitialPos);

    }
    /*********************************************************/

    void InitializeInitialPositions() {

    }
    /*********************************************************/

    void CheckRightMovement() {
        R_middlePos = R_middle.transform.position;
    }
    /*********************************************************/

    void CheckMovementOne () {
        indexPosG = indexG.transform.position;
        thumbPosG = thumbG.transform.position;
        indexPosD = indexD.transform.position;
        thumbPosD = thumbD.transform.position;

        Vector3 distanceG = CalculDistance(indexPosG, thumbPosG);
        Vector3 distanceD = CalculDistance(indexPosD, thumbPosD);

        // Debug.Log(distanceG.magnitude);

        //textG.SetActive(distanceG.magnitude < 0.03f);
        //textD.SetActive(distanceD.magnitude < 0.03f);
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
