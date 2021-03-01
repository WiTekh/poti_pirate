using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public GameObject boatSelectionMenu;
    public GameObject mainMenu;
    
    public void Play()
    {
        mainMenu.SetActive(false);
        boatSelectionMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        boatSelectionMenu.SetActive(false);
    }

    public void Settings()
    {
        Debug.Log("Opening Settings..");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene(int p_bato)
    {
        Inventory.monbato = p_bato;
        switch (p_bato)
        {
            case 0:
                Inventory.cannonball = 10;
                Inventory.planks = 3;
                break;
            case 1:
                Inventory.food = 10;
                Inventory.water = 10;
                break;
            case 2:
                Inventory.planks = 9;
                break;
        }
        SceneManager.LoadScene("Game1");
    }
}
