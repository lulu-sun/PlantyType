using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image settingsMenu;
    // [SerializeField] private Image endingMenu;

    public static sceneManager Instance
    {
        get;
        private set;
    }
    void Start()
    {
        AudioManager.Instance.PlayMainMusic();
        buttonBehavior.Instance.showTitle();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the active state of the image GameObject
            settingsMenu.gameObject.SetActive(!settingsMenu.gameObject.activeSelf);
            
        }
    }
}
