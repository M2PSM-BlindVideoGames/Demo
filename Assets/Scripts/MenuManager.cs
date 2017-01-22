using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {

    public Button centralBtn;
    public Button topBtn;
    public Button leftBtn;
    public Button rightBtn;

    public GameObject confirmationPanel;
    Button yesBtn;
    Button noBtn;

    public GameObject optionPanel;
    Slider _volumeSlider;

    delegate void btnDelegate();
    private List<btnDelegate> btnMethods;

	// Use this for initialization
	void Start () {
        _volumeSlider = optionPanel.transform.GetChild(0).GetComponent<Slider>();

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

        OpenPanel(confirmationPanel, false);
    }
    /*********************************************************/

    void InitializeMenuButtons() {
        leftBtn.interactable = false;
        rightBtn.interactable = false;

        btnMethods = new List<btnDelegate>();
        btnMethods.Add(Btn_LaunchNewGame);
        btnMethods.Add(Btn_OpenVolumePanel);
        centralBtn.onClick.AddListener(() => btnMethods[0]());
    }
    /*********************************************************/

    void Btn_LaunchNewGame() {
        SceneManager.LoadScene(1);
    }
    /*********************************************************/

    void OpenPanel(GameObject a_panel, bool a_isClosed = true) {
        a_panel.GetComponent<CanvasGroup>().alpha = a_isClosed ? 1 : 0;
        a_panel.GetComponent<CanvasGroup>().interactable = a_isClosed;
        a_panel.GetComponent<CanvasGroup>().blocksRaycasts = a_isClosed;
    }
    /*********************************************************/

    void Btn_OpenVolumePanel() {
        OpenPanel(optionPanel);
    }
    /*********************************************************/
    void Btn_CloseVolumePanel() {
        OpenPanel(optionPanel, false);
    }
    /*********************************************************/

    public void Btn_OpenConfirmationPanel() {
        OpenPanel(confirmationPanel);
    }
    /*********************************************************/
    public void Btn_CloseConfirmationPanel() {
        OpenPanel(confirmationPanel, false);
    }
    /*********************************************************/

    public void Btn_QuitGame() {
        Application.Quit();
    }
    /*********************************************************/
}
