using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject Menu;
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
        if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene(0);
    }
}
