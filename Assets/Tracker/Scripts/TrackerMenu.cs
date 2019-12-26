using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;

public class TrackerMenu : MonoBehaviour
{
    public Button LoadFileLocationButton;
    public Button SaveFileButton;
    public Button ReturnToMenuButton;

    public TrackerManager Manager;

    [DllImport("user32.dll")]
    private static extern void OpenFileDialog();

    //[DllImport("user32.dll")]
    //private static extern void SaveFileDialog();

    // Use this for initialization
    void Start ()
    {
        LoadFileLocationButton.onClick.AddListener(onLoadFileLocationButtonPressed);
        //SaveFileButton.onClick.AddListener(onSaveFileButtonPressed);
        ReturnToMenuButton.onClick.AddListener(onReturnToMenuButtonPressed);
	}

    void onLoadFileLocationButtonPressed()
    {
        System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();

        ofd.DefaultExt = "xshadowprofile";
        ofd.Filter = "xshadowprofile (*.xshadowprofile)|*.xshadowprofile";

        var result = ofd.ShowDialog();

        if (result == System.Windows.Forms.DialogResult.OK && File.Exists(ofd.FileName))
        {
            Common.XShadowProfileLocation = ofd.FileName;
            Common.ShadowProfileData = new XShadowProfileData(ofd.FileName);
            Common.SaveConfigFile();
        }
    }

    void onReturnToMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
