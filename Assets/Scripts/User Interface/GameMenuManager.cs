using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject Menu;
    private bool m_isOpen = false;

    void Update()
    {
        //If 'Esc' pressed, pause the InGame time, and display the menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!m_isOpen)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }

            Menu.SetActive(!m_isOpen);
            m_isOpen = !m_isOpen;
        }
    }

    //Back to menu WITHOUT SAVE
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
