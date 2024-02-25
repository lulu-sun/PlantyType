using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonBehavior : MonoBehaviour
{
    [SerializeField] private Image mainGame;
    [SerializeField] private Image settingsMenu;

    [SerializeField] private Image endResults;
    [SerializeField] private Image titleScreen;
    [SerializeField] private Image introScreen;

    public textScroller textScrollerInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public static buttonBehavior Instance
    {
        get;
        private set;
    }

    public void changePrompt()
    {
        TMP_Text textComponent = textScrollerInstance.GetTextComponent();
        textScroller.promptIndex = (textScroller.promptIndex + 1) % 3;
        textComponent.text = textScroller.prompts[textScroller.promptIndex];
        textScrollerInstance.resetTextScrollingSettings();
        // StartScrollTextCoroutine();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void moveToGame()
    {
        textScrollerInstance.resetTextScrollingSettings();
        introScreen.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        endResults.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        mainGame.gameObject.SetActive(true);
        
    }

     public void showTitle()
    {
        introScreen.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        endResults.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        mainGame.gameObject.SetActive(false);
        
    }

    public void moveToIntro()
    {
        introScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    public void playAgain()
    {
        Debug.Log("clicked");
        settingsMenu.gameObject.SetActive(false);
        textScrollerInstance.closeEndingMenu();
        changePrompt();
        moveToGame();

    }

    public void increaseDelay()
    {
        if (textScroller.scrollSpeed <= 2f)
        {
        textScroller.scrollSpeed += 0.05f;
        AudioManager.Instance.PlayTypingSfx();
        }
    }

    public void decreaseDelay()
    {
        if (textScroller.scrollSpeed >= 0.1f)
        {
        textScroller.scrollSpeed -= 0.05f;
        AudioManager.Instance.PlayTypingSfx();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
