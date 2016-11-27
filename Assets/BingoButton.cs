using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BingoButton : MonoBehaviour
{
	BingoObjective ObjectiveSettings;

	public bool Player1Obtained;
	public bool Player2Obtained;
	public bool Player3Obtained;
	public bool Player4Obtained;
	public bool Player5Obtained;
	public bool Player6Obtained;
	public bool Player7Obtained;
	public bool Player8Obtained;

    private bool Player1ObtainedStorage;
    private bool Player2ObtainedStorage;
    private bool Player3ObtainedStorage;
    private bool Player4ObtainedStorage;
    private bool Player5ObtainedStorage;
    private bool Player6ObtainedStorage;
    private bool Player7ObtainedStorage;
    private bool Player8ObtainedStorage;

    public Image Player1ObtainedOverlay;
    public Image Player2ObtainedOverlay;
    public Image Player3ObtainedOverlay;
    public Image Player4ObtainedOverlay;
    public Image Player5ObtainedOverlay;
    public Image Player6ObtainedOverlay;
    public Image Player7ObtainedOverlay;
    public Image Player8ObtainedOverlay;

    public Button button;

	//Use this for initialization
	void Start () 
	{
		button.onClick.AddListener(onButtonPressed);
	}

    void Update()
    {
        if (Player1Obtained != Player1ObtainedStorage ||
            Player2Obtained != Player2ObtainedStorage ||
            Player3Obtained != Player3ObtainedStorage ||
            Player4Obtained != Player4ObtainedStorage ||
            Player5Obtained != Player5ObtainedStorage ||
            Player6Obtained != Player6ObtainedStorage ||
            Player7Obtained != Player7ObtainedStorage ||
            Player8Obtained != Player8ObtainedStorage)
        {
            updateOverlays();
        }
    }

    void updateOverlays()
    {
        Player1ObtainedStorage = Player1Obtained;
        Player2ObtainedStorage = Player2Obtained;
        Player3ObtainedStorage = Player3Obtained;
        Player4ObtainedStorage = Player4Obtained;
        Player5ObtainedStorage = Player5Obtained;
        Player6ObtainedStorage = Player6Obtained;
        Player7ObtainedStorage = Player7Obtained;
        Player8ObtainedStorage = Player8Obtained;

        Player1ObtainedOverlay.enabled = false;
        Player2ObtainedOverlay.enabled = false;
        Player3ObtainedOverlay.enabled = false;
        Player4ObtainedOverlay.enabled = false;
        Player5ObtainedOverlay.enabled = false;
        Player6ObtainedOverlay.enabled = false;
        Player7ObtainedOverlay.enabled = false;
        Player8ObtainedOverlay.enabled = false;

        List<Image> activeOverlays = new List<Image>();

        if (Player1Obtained)
        {
            activeOverlays.Add(Player1ObtainedOverlay);
        }
        if (Player2Obtained)
        {
            activeOverlays.Add(Player2ObtainedOverlay);
        }
        if (Player3Obtained)
        {
            activeOverlays.Add(Player3ObtainedOverlay);
        }
        if (Player4Obtained)
        {
            activeOverlays.Add(Player4ObtainedOverlay);
        }
        if (Player5Obtained)
        {
            activeOverlays.Add(Player5ObtainedOverlay);
        }
        if (Player6Obtained)
        {
            activeOverlays.Add(Player6ObtainedOverlay);
        }
        if (Player7Obtained)
        {
            activeOverlays.Add(Player7ObtainedOverlay);
        }
        if (Player8Obtained)
        {
            activeOverlays.Add(Player8ObtainedOverlay);
        }

        foreach (var overlay in activeOverlays)
        {
            overlay.enabled = true;
        }

        switch (activeOverlays.Count)
        {
            case 0:
                break;
            case 1:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(1, 1);
                break;
            case 2:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0.5f);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(1, 1);
                activeOverlays[1].rectTransform.anchorMin = new Vector2(0, 0);
                activeOverlays[1].rectTransform.anchorMax = new Vector2(1, 0.5f);
                break;
            case 3:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0.5f);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(0.5f, 1);
                activeOverlays[1].rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                activeOverlays[1].rectTransform.anchorMax = new Vector2(1, 1);
                activeOverlays[2].rectTransform.anchorMin = new Vector2(0, 0);
                activeOverlays[2].rectTransform.anchorMax = new Vector2(1, 0.5f);
                break;
            case 4:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0.5f);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(0.5f, 1);
                activeOverlays[1].rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                activeOverlays[1].rectTransform.anchorMax = new Vector2(1, 1);
                activeOverlays[2].rectTransform.anchorMin = new Vector2(0, 0);
                activeOverlays[2].rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                activeOverlays[3].rectTransform.anchorMin = new Vector2(0.5f, 0);
                activeOverlays[3].rectTransform.anchorMax = new Vector2(1, 0.5f);
                break;
            case 5:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0.5f);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(0.3333333f, 1);
                activeOverlays[1].rectTransform.anchorMin = new Vector2(0.3333333f, 0.5f);
                activeOverlays[1].rectTransform.anchorMax = new Vector2(0.6666666f, 1);
                activeOverlays[2].rectTransform.anchorMin = new Vector2(0.6666666f, 0.5f);
                activeOverlays[2].rectTransform.anchorMax = new Vector2(1, 1);
                activeOverlays[3].rectTransform.anchorMin = new Vector2(0, 0);
                activeOverlays[3].rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                activeOverlays[4].rectTransform.anchorMin = new Vector2(0.5f, 0);
                activeOverlays[4].rectTransform.anchorMax = new Vector2(1, 0.5f);
                break;
            case 6:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0.5f);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(0.3333333f, 1);
                activeOverlays[1].rectTransform.anchorMin = new Vector2(0.3333333f, 0.5f);
                activeOverlays[1].rectTransform.anchorMax = new Vector2(0.6666666f, 1);
                activeOverlays[2].rectTransform.anchorMin = new Vector2(0.6666666f, 0.5f);
                activeOverlays[2].rectTransform.anchorMax = new Vector2(1, 1);
                activeOverlays[3].rectTransform.anchorMin = new Vector2(0, 0);
                activeOverlays[3].rectTransform.anchorMax = new Vector2(0.3333333f, 0.5f);
                activeOverlays[4].rectTransform.anchorMin = new Vector2(0.3333333f, 0);
                activeOverlays[4].rectTransform.anchorMax = new Vector2(0.6666666f, 0.5f);
                activeOverlays[5].rectTransform.anchorMin = new Vector2(0.6666666f, 0);
                activeOverlays[5].rectTransform.anchorMax = new Vector2(1, 0.5f);
                break;
            case 7:
                activeOverlays[0].rectTransform.anchorMin = new Vector2(0, 0.6666666f);
                activeOverlays[0].rectTransform.anchorMax = new Vector2(0.3333333f, 1);
                activeOverlays[1].rectTransform.anchorMin = new Vector2(0.3333333f, 0.6666666f);
                activeOverlays[1].rectTransform.anchorMax = new Vector2(0.6666666f, 1);
                activeOverlays[2].rectTransform.anchorMin = new Vector2(0.6666666f, 0.6666666f);
                activeOverlays[2].rectTransform.anchorMax = new Vector2(1, 1);
                activeOverlays[3].rectTransform.anchorMin = new Vector2(0, 0.5f);
                activeOverlays[3].rectTransform.anchorMax = new Vector2(0.3333333f, 0.6666666f);
                activeOverlays[4].rectTransform.anchorMin = new Vector2(0.3333333f, 0.3333333f);
                activeOverlays[4].rectTransform.anchorMax = new Vector2(0.6666666f, 0.6666666f);
                activeOverlays[5].rectTransform.anchorMin = new Vector2(0.6666666f, 0);
                activeOverlays[5].rectTransform.anchorMax = new Vector2(1, 0.5f);
                activeOverlays[6].rectTransform.anchorMin = new Vector2(0.6666666f, 0);
                activeOverlays[6].rectTransform.anchorMax = new Vector2(1, 0.5f);
                break;
            case 8:
                break;
            default:
                Debug.LogError("Unexpected number of overlays");
                break;
        }
    }
    
    void onButtonPressed()
    {
        onButtonPressed(0);
    }

	void onButtonPressed(int playerIndex)
	{
		switch (playerIndex) 
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			Player1Obtained = !Player1Obtained;
			break;
		}
	}
}
