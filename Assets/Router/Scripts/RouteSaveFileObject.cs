using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteSaveFileObject : MonoBehaviour
{
    private string fileName;
    private bool isFavorite;
    private List<RoutingPathObject> RoutingPaths = new List<RoutingPathObject>();

    public Button OpenButton;
    public Button FavoriteButton;
    public Button DeleteButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Setup(string v1, bool v2)
    {
        fileName = v1;
        isFavorite = v2;

        OpenButton.GetComponentInChildren<Text>().text = fileName;
    }
}
