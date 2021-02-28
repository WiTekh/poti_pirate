using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject TransitionMenu;
    
    private bool m_isOpen = false;
    private bool m_isCursorVisible = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //If 'Esc' pressed, pause the InGame time, and display the menu
        if (Input.GetKeyDown(KeyCode.Escape) && !Inventory.isDed)
        {
            if (!m_isOpen)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }

            Menu.SetActive(!m_isOpen);
            
            m_isOpen = !m_isOpen;
            m_isCursorVisible = !m_isCursorVisible;
        }
    }

    //Back to menu WITHOUT SAVE
    public void BackToMenu()
    {
        //RESET GAME1 SOMEHOW
        SceneManager.LoadScene(0);
    }

    public void Leave()
    {
        SceneManager.LoadScene("Game2");
    }

    public void Stay()
    {
        TransitionMenu.SetActive(false);
    }
}
