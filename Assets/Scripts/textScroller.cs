using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class textScroller : MonoBehaviour
{
    [SerializeField] private TMP_Text player1ScoreDisplay;
    [SerializeField] private TMP_Text player2ScoreDisplay;
    [SerializeField] private Image endingMenu;

    public TMP_Text textComponent; // Reference to the TMP text component
    public TMP_Text endingResults;
    public static float scrollSpeed; // Speed of scrolling (in seconds)
    private string fullText;
    private string currentText = "";

    private string currentKey;
    private int currentIndex = 0;
    private bool reset = false;
    private bool localReset;
    private bool keypressCheckingOn = false;
    public static int player1TotalCount = 0;
    public static int player2TotalCount = 0;

    public static int player1CurrentCount = 0;
    public static int player2CurrentCount = 0;
    public static bool letterChecked = false;

    public static List<string> prompts = new List<string>(){"the monstera deliciosa is a tropical house plant", "philodendrons are aroids with heart shaped leaves", "epipremnum aureum come in a variety of colors"};
    public static int promptIndex = 0;

    public static textScroller Instance
    {
        get;
        private set;
    }

    public TMP_Text GetTextComponent()
    {
        return textComponent;
    }

    public void closeEndingMenu()
    {
        endingMenu.gameObject.SetActive(false);
    }

    public void openEndingMenu()
    {
        endingMenu.gameObject.SetActive(true);
    }

    void Start()
    {
        closeEndingMenu();
        scrollSpeed = 0.8f;
        // Check if the text component is assigned
        if (textComponent == null)
        {
            Debug.LogError("Text component not assigned!");
            return;
        }

        player1ScoreDisplay.text = (player1CurrentCount).ToString() + "/" + (player1TotalCount).ToString();
        player2ScoreDisplay.text = (player2CurrentCount).ToString() + "/" + (player2TotalCount).ToString();

        // StartTextScrollingSettings();
        textComponent.text = prompts[promptIndex];
        // Store the full text
        fullText = textComponent.text;

        foreach (char c in fullText)
        {
            string charAsString = c.ToString();

            if (scoreTracker.player1Keys.Contains(charAsString.ToUpper()))
            {
                player1TotalCount += 1;
            }

            else if (scoreTracker.player2Keys.Contains(charAsString.ToUpper()))
            {
                player2TotalCount += 1;
            }

        }

        player1ScoreDisplay.text = (player1CurrentCount).ToString() + "/" + (player1TotalCount).ToString();
        player2ScoreDisplay.text = (player2CurrentCount).ToString() + "/" + (player2TotalCount).ToString();

        // Clear the text component
        textComponent.text = "";

        // Start scrolling coroutine
        StartCoroutine("ScrollText");

        // openEndingMenu();
        // endingResults.text = ((player1CurrentCount+player2CurrentCount)*100.0/(player1TotalCount+player2TotalCount)).ToString("F2") + "%";

    }

    public void resetTextScrollingSettings()
    {
        reset = true;
        StopCoroutine("ScrollText");
        currentIndex = 0;
        keypressCheckingOn = true;
        currentText = "";
        player1CurrentCount = 0;
        player2CurrentCount = 0;
        player1TotalCount = 0;
        player2TotalCount = 0;

        textComponent.text = prompts[promptIndex];
        fullText = textComponent.text;


        foreach (char c in fullText)
        {
            string charAsString = c.ToString();

            if (scoreTracker.player1Keys.Contains(charAsString.ToUpper()))
            {
                player1TotalCount += 1;
            }

            else if (scoreTracker.player2Keys.Contains(charAsString.ToUpper()))
            {
                player2TotalCount += 1;
            }

        }

        // Clear the text component
        textComponent.text = "";
        reset = false;
        StartCoroutine("ScrollText");
    
    }

    IEnumerator ScrollText()
    {
        yield return new WaitForSeconds(2f);
        keypressCheckingOn = true;

        // Iterate over each character in the full text
        for (int i = currentIndex; i < fullText.Length; i++)
        {   
            letterChecked = false; // Each letter gets point credit once
            // Update the current text to display
            currentText = fullText.Substring(0, i+1);            
            currentKey = fullText[i].ToString().ToUpper();

            if (currentKey == " ")
            {
                currentKey = "Space"; // Maybe future updates can use spacebar
            }
            // Assign the current text to the TMP text component
            textComponent.text = currentText;
            // Wait for a short duration
            yield return new WaitForSeconds(scrollSpeed);
        }
        keypressCheckingOn = false; // Stop checking for key presses after completion
        // End of round actions: Show ending screen, update results
        openEndingMenu();
        endingResults.text = ((player1CurrentCount+player2CurrentCount)*100.0/(player1TotalCount+player2TotalCount)).ToString("F2") + "%";
    }

    void Update()
    {
        player1ScoreDisplay.text = (player1CurrentCount).ToString() + "/" + (player1TotalCount).ToString();
        player2ScoreDisplay.text = (player2CurrentCount).ToString() + "/" + (player2TotalCount).ToString();

        if (keypressCheckingOn)
        // Check for keyboard input
        {
            if (Input.anyKeyDown)
            {
                // Loop through all possible KeyCode values
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    // Check if the key with this KeyCode was pressed down
                    if (Input.GetKeyDown(keyCode))
                    {
                        AudioManager.Instance.PlayTypingSfx();
                        // Check if the pressed key matches the stringToCheck
                        if (keyCode.ToString() == currentKey)
                        {
                            // If player 1 correctly gets the letter:
                            if (scoreTracker.player1Keys.Contains(keyCode.ToString().ToUpper()) && !letterChecked)
                            {
                                player1CurrentCount += 1;
                                letterChecked = true;
                            }
                            // If Player 2 correctly gets the letter:
                            else if (scoreTracker.player2Keys.Contains(keyCode.ToString().ToUpper()) && !letterChecked)
                            {
                                player2CurrentCount += 1;
                                letterChecked = true;
                            }
                            // Update the scoring
                            player1ScoreDisplay.text = (player1CurrentCount).ToString() + "/" + (player1TotalCount).ToString();
                            player2ScoreDisplay.text = (player2CurrentCount).ToString() + "/" + (player2TotalCount).ToString();
                        }
                    }
                }
            }
            
            
        }
    }
}
