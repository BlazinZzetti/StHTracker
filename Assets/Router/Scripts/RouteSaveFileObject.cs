using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class RouteSaveFileObject : MonoBehaviour
{
    private string fileName;
    public string fileLocation;

    public bool isNewFile;
    public bool isNoCCG;
    private bool isFavorite;
    public List<RoutingPathData> RoutingPaths = new List<RoutingPathData>();

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

    public bool Setup(string filepath)
    {
        fileName = string.Empty;
        fileLocation = string.Empty;
        isFavorite = false;
        RoutingPaths.Clear();

        fileLocation = filepath;
        XmlDocument xml = new XmlDocument();

        if (File.Exists(filepath))
        {
            fileName = Path.GetFileName(filepath).Replace(".xshadowroute", "");

            xml.Load(filepath);

            //Get Database Location stored in configXml.
            foreach (XmlElement node in xml.DocumentElement)
            {
                if (node.Name == "NewGame")
                {
                    isNewFile = Boolean.Parse(node.InnerText);
                }
                if (node.Name == "NoCCG")
                {
                    isNoCCG = Boolean.Parse(node.InnerText);
                }
                if (node.Name == "Favortie")
                {
                    isFavorite = Boolean.Parse(node.InnerText);
                }
                if (node.Name == "Paths")
                {
                    foreach (XmlElement path in node.ChildNodes)
                    {
                        if (path.Name == "Path")
                        {
                            var pathNumberString = path.GetAttribute("number");
                            var pathNumber = Int32.Parse(pathNumberString);
                            var pathCode = path.GetAttribute("code");
                            var pathDisplay = path.GetAttribute("display");

                            bool[,] stageKeys = new bool[6, 5];

                            for(int i = 0; i < 6; i++) 
                            {
                                var keys = (XmlElement)path.ChildNodes[i];
                                if (keys.Name == "Keys")
                                {
                                    stageKeys[i,0] = bool.Parse(keys.GetAttribute("key1"));
                                    stageKeys[i,1] = bool.Parse(keys.GetAttribute("key2"));
                                    stageKeys[i,2] = bool.Parse(keys.GetAttribute("key3"));
                                    stageKeys[i,3] = bool.Parse(keys.GetAttribute("key4"));
                                    stageKeys[i,4] = bool.Parse(keys.GetAttribute("key5"));
                                }                                    
                            }
                            RoutingPaths.Add(new RoutingPathData(pathNumber, pathCode, (RoutingPathData.DisplayType)Enum.Parse(typeof(RoutingPathData.DisplayType), pathDisplay), stageKeys));
                        }
                    }
                }
            }

            OpenButton.GetComponentInChildren<Text>().text = fileName;
            return true;
        }
        return false;
    }
}
