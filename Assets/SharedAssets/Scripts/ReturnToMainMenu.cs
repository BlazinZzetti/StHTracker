using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public bool MenuMode = false;

    public Canvas MenuCamera;

    // Update is called once per frame
	void Update ()
    {
        //Return to Main Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MenuMode)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                MenuCamera.enabled = !MenuCamera.enabled;
            }
        }
    }
}
