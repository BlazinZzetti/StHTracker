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
    public List<ExtraStageData> ExtraStages = new List<ExtraStageData>();

    public Button OpenButton;
    public Button FavoriteButton;
    public Button DeleteButton;

    public bool Setup(string filepath)
    {
        fileName = string.Empty;
        fileLocation = string.Empty;
        isFavorite = false;
        RoutingPaths.Clear();
        ExtraStages.Clear();

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
                if (node.Name == "ExtraStages")
                {
                    foreach (XmlElement extraStage in node.ChildNodes)
                    {
                        if (extraStage.Name == "ExtraStage")
                        {
                            var level = extraStage.GetAttribute("level");
                            var mission = extraStage.GetAttribute("mission");

                            bool[] stageKeys = new bool[5];
                            var keys = (XmlElement)extraStage.ChildNodes[0];
                            if (keys.Name == "Keys")
                            {
                                stageKeys[0] = bool.Parse(keys.GetAttribute("key1"));
                                stageKeys[1] = bool.Parse(keys.GetAttribute("key2"));
                                stageKeys[2] = bool.Parse(keys.GetAttribute("key3"));
                                stageKeys[3] = bool.Parse(keys.GetAttribute("key4"));
                                stageKeys[4] = bool.Parse(keys.GetAttribute("key5"));
                            }

                            ExtraStages.Add(new ExtraStageData
                            {
                                levelName = level,
                                missionString = mission,
                                keys = stageKeys
                            });
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
