using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Button centralBtn;
    public Button topBtn;
    public Button leftBtn;
    public Button rightBtn;

    public GameObject confirmationPanel;
    Button yesBtn;
    Button noBtn;

	// Use this for initialization
	void Start () {
        InitializeConfirmationsButtons();
        InitializeMenuButtons();
    }
    /*********************************************************/

    // Update is called once per frame
    void Update () {
    }
    /*********************************************************/

    void InitializeConfirmationsButtons() {
        yesBtn = confirmationPanel.transform.GetChild(0).GetComponent<Button>();
        noBtn = confirmationPanel.transform.GetChild(1).GetComponent<Button>();

        confirmationPanel.SetActive(false);
    }
    /*********************************************************/

    void InitializeMenuButtons() {
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        centralBtn.onClick.AddListener(() => Btn_LaunchNewGame());
    }
    /*********************************************************/

    void Btn_LaunchNewGame() {
        SceneManager.LoadScene(1);
    }
    /*********************************************************/

    public void Btn_OpenConfirmationPanel() {
        confirmationPanel.SetActive(true);
    }
    /*********************************************************/

    public void Btn_CloseConfirmationPanel() {
        confirmationPanel.SetActive(false);
    }
    /*********************************************************/

    public void Btn_QuitGame() {
        Application.Quit();
    }
    /*********************************************************/
}
