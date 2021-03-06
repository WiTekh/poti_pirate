using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject settingsMenu;
    public GameObject TransitionMenu;
    public GameObject Player;
    public GameObject Victory;
    public GameObject Death;

    private bool m_isOpen = false;
    private bool m_isCursorVisible = false;

    private void Start()
    {
        Death = GameObject.Find("Death");
        Death.SetActive(false);
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

            escMenu.SetActive(!m_isOpen);
            
            m_isOpen = !m_isOpen;
            m_isCursorVisible = !m_isCursorVisible;
        }
    }

    //Back to menu WITHOUT SAVE
    public void BackToMenu()
    {
        Application.Quit();
    }

    public void Leave()
    {
        if (Inventory.treasure == false)
        {
            TransitionMenu.SetActive(false);
            Death.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Game2");
        }
    }

    public void Stay()
    {
        TransitionMenu.SetActive(false);
        Player.GetComponent<new_TPS_Movement.new_TPS_Movement>().m_canMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenSettings()
    {
        escMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void BackSettings()
    {
        escMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void LeaveEscMenu()
    {
        escMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
