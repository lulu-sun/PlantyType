using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class settingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text speedDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedDisplay.text = textScroller.scrollSpeed.ToString("F2");
    }
}
