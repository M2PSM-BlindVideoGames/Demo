using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BasicMovement : MonoBehaviour {

    public GameObject textG;
    public GameObject textD;

    [Header("Gauche")]
    public GameObject indexG;
    public GameObject thumbG;
    [Header("Droite")]
    public GameObject indexD;
    public GameObject thumbD;

    private Vector3 indexPosG;
    private Vector3 thumbPosG;
    private Vector3 indexPosD;
    private Vector3 thumbPosD;
    
///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
	}
    /*********************************************************/
	
	void Update () {
        CheckMovementOne();
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void CheckMovementOne () {
        indexPosG = indexG.transform.position;
        thumbPosG = thumbG.transform.position;
        indexPosD = indexD.transform.position;
        thumbPosD = thumbD.transform.position;

        Vector3 distanceG = CalculDistance(indexPosG, thumbPosG);
        Vector3 distanceD = CalculDistance(indexPosD, thumbPosD);

        // Debug.Log(distanceG.magnitude);

        textG.SetActive(distanceG.magnitude < 0.03f);
        textD.SetActive(distanceD.magnitude < 0.03f);
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
