using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public int LayoutIndex = 0;
    private struct LayoutSettings
    {
        public Vector2Int resolution;

        public Rect TrackerCameraViewport;
        public Rect MenuCameraViewport;
        public Rect RoutingCameraViewport;
        public Rect PathMenuCameraViewport;
        public Rect KeysCameraViewport;

        public bool MenuCameraEnabled;
        public bool RoutingCameraEnabled;
        public bool PathMenuCameraEnabled;
        public bool KeysCameraEnabled;

        public CameraClearFlags MenuCameraClearFlags;
        public CameraClearFlags RoutingCameraClearFlags;
        public CameraClearFlags PathMenuCameraClearFlags;
        public CameraClearFlags KeysCameraClearFlags;
    }

    private List<LayoutSettings> LayoutModes;

    public Camera TrackerCamera;
    public Camera MenuCamera;
    public Camera RoutingCamera;
    public Camera PathMenuCamera;
    public Camera KeysCamera;

    public Canvas MenuCanvas;
    public Canvas RoutingCanvas;
    public Canvas PathMenuCanvas;
    public Canvas KeysCanvas;

    private void Awake()
    {
        //Screen.SetResolution(640, 480, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        LayoutModes = new List<LayoutSettings>();
        //Small Layout
        LayoutModes.Add(new LayoutSettings
        {
            resolution = new Vector2Int(640, 480),
            TrackerCameraViewport = new Rect(0, 0, 1, 1),
            MenuCameraViewport = new Rect(0, 0, 1, 1),
            RoutingCameraViewport = new Rect(0, 0, 1, 1),
            PathMenuCameraViewport = new Rect(0, 0, 1, 1),
            KeysCameraViewport = new Rect(0, 0, 1, 1),
            MenuCameraEnabled = false,
            RoutingCameraEnabled = false,
            PathMenuCameraEnabled = false,
            KeysCameraEnabled = false,
            MenuCameraClearFlags = CameraClearFlags.Depth,
            RoutingCameraClearFlags = CameraClearFlags.Depth,
            PathMenuCameraClearFlags = CameraClearFlags.Depth,
            KeysCameraClearFlags = CameraClearFlags.Depth,
        });

        //Large Layout
        LayoutModes.Add(new LayoutSettings
        {
            resolution = new Vector2Int(1280, 960),
            TrackerCameraViewport = new Rect(0, 0.5f, 0.5f, 0.5f),
            MenuCameraViewport = new Rect(-0.23f, 0, 0.5f, 0.5f),
            RoutingCameraViewport = new Rect(0.5f, 0, 0.5f, 0.5f),
            PathMenuCameraViewport = new Rect(0.12f, 0, 0.5f, 0.5f),
            KeysCameraViewport = new Rect(0.5f, 0.5f, 0.5f, 0.5f),
            MenuCameraEnabled = true,
            RoutingCameraEnabled = true,
            PathMenuCameraEnabled = true,
            KeysCameraEnabled = true,
            MenuCameraClearFlags = CameraClearFlags.SolidColor,
            RoutingCameraClearFlags = CameraClearFlags.SolidColor,
            PathMenuCameraClearFlags = CameraClearFlags.SolidColor,
            KeysCameraClearFlags = CameraClearFlags.SolidColor,
        });

        DisplayLayout(LayoutModes[LayoutIndex]);
    }

    // Update is called once per frame
    public void SwitchLayout()
    {
        LayoutIndex++;
        if(LayoutIndex >= LayoutModes.Count)
        {
            LayoutIndex = 0;
        }
        DisplayLayout(LayoutModes[LayoutIndex]);           
    }

    private void DisplayLayout(LayoutSettings layout)
    {
        Screen.SetResolution(layout.resolution.x, layout.resolution.y, false);

        TrackerCamera.enabled = true;
        TrackerCamera.rect = layout.TrackerCameraViewport;

        MenuCanvas.enabled = layout.MenuCameraEnabled;
        MenuCamera.enabled = layout.MenuCameraEnabled;
        MenuCamera.rect = layout.MenuCameraViewport;
        MenuCamera.clearFlags = layout.MenuCameraClearFlags;

        RoutingCanvas.enabled = layout.RoutingCameraEnabled;
        RoutingCamera.enabled = layout.RoutingCameraEnabled;
        RoutingCamera.rect = layout.RoutingCameraViewport;
        RoutingCamera.clearFlags = layout.RoutingCameraClearFlags;

        PathMenuCanvas.enabled = layout.PathMenuCameraEnabled;
        PathMenuCamera.enabled = layout.PathMenuCameraEnabled;
        PathMenuCamera.rect = layout.PathMenuCameraViewport;
        PathMenuCamera.clearFlags = layout.PathMenuCameraClearFlags;

        KeysCanvas.enabled = layout.KeysCameraEnabled;
        KeysCamera.enabled = layout.KeysCameraEnabled;
        KeysCamera.rect = layout.KeysCameraViewport;
        KeysCamera.clearFlags = layout.KeysCameraClearFlags;
    }
}
