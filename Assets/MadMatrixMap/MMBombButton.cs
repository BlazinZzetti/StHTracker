using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MMBombButton : MonoBehaviour
{
    public bool BombAlive = true;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(OnButtonPressed);
    }

	// Update is called once per frame
	void Update ()
    {
        if (BombAlive)
        {
            gameObject.GetComponent<Image>().color = new Color(255,0,243);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(255,0,0);
        }	    
	}

    void OnButtonPressed()
    {
        BombAlive = !BombAlive;
    }
}
