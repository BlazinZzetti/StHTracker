using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Button TrackerButton;
    public Button PathViewerButton;
    public Button BingoButton;
    public Button MadMatrixMapButton;

	// Use this for initialization
	void Start ()
    {
        TrackerButton.onClick.AddListener(onTrackerButtonPressed);
        PathViewerButton.onClick.AddListener(onPathViewerButtonPressed);
        BingoButton.onClick.AddListener(onBingoButtonPressed);
        MadMatrixMapButton.onClick.AddListener(onMadMatrixButtonPressed);
    }

    void onTrackerButtonPressed()
    {
        SceneManager.LoadScene("Tracker");
    }

    void onPathViewerButtonPressed()
    {
        //Load Path Viewer Scene
    }

    void onBingoButtonPressed()
    {
        //Load Bingo Scene
    }

    void onMadMatrixButtonPressed()
    {
        SceneManager.LoadScene("MadMatrixMap");
    }
}
