using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI_SecurityLock : MonoBehaviour {

    public GameObject PanelUI;
    private UIO_SecurityLock SecurityLock;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        for (int i = 0; i < PanelUI.transform.childCount; i++) {
            Transform piou = PanelUI.transform.GetChild(i).transform;
            if (piou.GetComponent<UIO_SecurityLock>()) {
                SecurityLock = piou.GetComponent<UIO_SecurityLock>();
                break;
            }
        }
    }
    /*********************************************************/
    
    void Update () {
	    if (IsDoorUnlocked()) {
            PanelUI.SetActive(false);
        }
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    bool IsDoorUnlocked() {
        return SecurityLock.IsDoorUnlocked();
    }
    /*********************************************************/
}
