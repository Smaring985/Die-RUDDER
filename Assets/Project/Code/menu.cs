using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string Scene;
    public GameObject Mainmenu;
    public GameObject Setting;
    public GameObject Create;
    public GameObject HeroPanel;



    public GameObject CameraMainmenu;
    public GameObject CameraHero;



    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        
    }

    


    public void MenuCountActive(int countActiveMenu)
    {
        switch (countActiveMenu)
        {
            case 1:
                // октрытие главного Меню
                CameraMainmenu.SetActive(true);
                Mainmenu.SetActive(true);
                Setting.SetActive(false);
                CameraHero.SetActive(false);
                // Create.SetActive(false);
                HeroPanel.SetActive(false);
                break;

            case 2:
                //открытие Выбора персонажей

                HeroPanel.SetActive(true);
                Mainmenu.SetActive(false);
                Setting.SetActive(false);
                CameraHero.SetActive(true);
                CameraMainmenu.SetActive(false);
                //  Create.SetActive(false);
                break;

            case 3:
                //открытие Создатели

                //Create.SetActive(true);
                HeroPanel.SetActive(false);
                Mainmenu.SetActive(false);
                Setting.SetActive(false);
                break;

            case 4:
                //открытие Настройки

                Setting.SetActive(true);
                HeroPanel.SetActive(false);
                Mainmenu.SetActive(false);
                //Create.SetActive(false);
                break;

        }

    }

    public void playScene()
    {
        SceneManager.LoadScene(Scene);
    }
    public void exti()
    {
        Application.Quit();
    }
}

