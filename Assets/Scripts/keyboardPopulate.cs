using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class keyboardPopulate : MonoBehaviour
{
    
    public Transform keyboardParent; // Parent object containing child images and texts
    public Transform letterParent; // Parent object containing child images and texts

    public char[] letters = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

    // Start is called before the first frame update
    void Start()
    {
        if (keyboardParent == null || letterParent == null)
        {
            Debug.LogError("Parent object not assigned!");
            return;
        }

        UpdateImageTexts();
    }

    void UpdateImageTexts()
    {
        // Get all child images and their corresponding text components
        Image[] childImages = keyboardParent.GetComponentsInChildren<Image>();
        TMP_Text[] childLetters = letterParent.GetComponentsInChildren<TMP_Text>();

        // Check if the number of text objects matches the number of letters
        if (childLetters.Length != letters.Length)
        {
            Debug.LogError("Number of text objects does not match the number of letters!");
            Debug.Log(childLetters.Length);
            return;
        }

        // Assign letters to text components of child images
        for (int i = 0; i < childLetters.Length; i++)
        {
            childLetters[i].text = letters[i].ToString();
        }
    }
}
