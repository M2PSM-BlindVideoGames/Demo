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
    private int _currentIndex;

    private LP_Movements _lpMvts;

    private List<Button> _btnsList;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    // Use this for initialization
    void Start () {
        _volumeSlider = optionPanel.transform.GetChild(1).GetComponent<Slider>();
        _lpMvts = GetComponent<LP_Movements>();

        InitializeConfirmationsButtons();
        InitializeMenuButtons();
        InitializeButtonList();
    }
    /*********************************************************/

    // Update is called once per frame
    void Update () {
        // Check hands are active : Check if LeapMotion is active
        if(_lpMvts.L_hand.activeSelf && _lpMvts.R_hand.activeSelf) {
            UpdateLeapMotionActions();
        } else {
            
        }
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void InitializeButtonList() {
        _btnsList = new List<Button>();
        _btnsList.Add(topBtn);
        _btnsList.Add(centralBtn);
        _btnsList.Add(leftBtn);
        _btnsList.Add(rightBtn);
        _btnsList.Add(yesBtn);
        _btnsList.Add(noBtn);
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
        rightBtn.interactable = true;

        btnMethods = new List<btnDelegate>();
        btnMethods.Add(Btn_LaunchNewGame);
        btnMethods.Add(Btn_OpenVolumePanel);
        _currentIndex = 0;
        centralBtn.onClick.AddListener(() => btnMethods[_currentIndex]());
        rightBtn.onClick.AddListener(() => Btn_Next());
    }
    /*********************************************************/

    void UpdateLeapMotionActions() {
        // If rightBtn interactable && right movement check : click right button
        if(_lpMvts.IsRightMvtChecked() && rightBtn.interactable) {
            LaunchButtonSound(rightBtn);
            Btn_Next();
        }
        // If leftBtn interactable && left movement check : click left button
        else if (_lpMvts.IsLeftMvtChecked() && leftBtn.interactable) {
            LaunchButtonSound(leftBtn);
            Btn_Previous();
        }
        // If closeMenu movement check...
        else if (_lpMvts.IsCloseMenuChecked()) {
            // ... && optionPanel visible : close optionPanel
            if (optionPanel.GetComponent<CanvasGroup>().alpha == 1) {
                LaunchButtonSound(topBtn);
                OpenPanel(optionPanel, false);
            // ... && optionPanel not visible : open confirmationPanel
            } else {
                LaunchButtonSound(topBtn);
                OpenPanel(confirmationPanel);
            }
        }
        // If confirmationPanel is visible : you can quit application or close confirmationPanel
        else if (confirmationPanel.GetComponent<CanvasGroup>().alpha == 1) {
            if(_lpMvts.IsYesMvtChecked()) {
                LaunchButtonSound(leftBtn);
                Application.Quit();
            }
            else if (_lpMvts.IsNoMvtChecked()) {
                LaunchButtonSound(rightBtn);
                OpenPanel(confirmationPanel, false);
            }
        }
        // Check Yes movement == click central button
        else if (_lpMvts.IsYesMvtChecked() && optionPanel.GetComponent<CanvasGroup>().alpha == 0) {
            LaunchButtonSound(centralBtn);
            btnMethods[_currentIndex]();
        }
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

    void LaunchButtonSound(Button a_btn) {
        foreach(Button btn in _btnsList) {
            btn.GetComponents<AudioSource>()[0].Stop();
        }
        a_btn.GetComponents<AudioSource>()[0].Play();
    }
    /*********************************************************/

    void Btn_Next() {
        _currentIndex++;
        centralBtn.onClick.RemoveAllListeners();
        centralBtn.onClick.AddListener(() => btnMethods[_currentIndex]());

        leftBtn.interactable = true;
        leftBtn.onClick.RemoveAllListeners();
        leftBtn.onClick.AddListener(() => Btn_Previous());

        if (_currentIndex == btnMethods.Count-1)
            rightBtn.interactable = false;
    }
    /*********************************************************/

    void Btn_Previous() {
        _currentIndex--;
        centralBtn.onClick.RemoveAllListeners();
        centralBtn.onClick.AddListener(() => btnMethods[_currentIndex]());

        rightBtn.interactable = true;
        rightBtn.onClick.RemoveAllListeners();
        rightBtn.onClick.AddListener(() => Btn_Next());

        if (_currentIndex == 0)
            leftBtn.interactable = false;
    }
    /*********************************************************/

    void Btn_OpenVolumePanel() {
        OpenPanel(optionPanel);
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PUBLIC FUNCTIONS //////////////////////////////////////////
///////////////////////////////////////////////////////////////
    public void Btn_CloseVolumePanel() {
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
