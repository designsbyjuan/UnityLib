using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour {

  public ViewManager viewManager;
  public Button[] buttons;
  public int fontSizeSelected = 16;
  public int fontSize = 14;

  private SkyboxInfo[] skyboxInfo;
  private Text text;

  // Use this for initialization
  void Start()
  {
    skyboxInfo = viewManager.SkyboxList;
  }
	
  // Update is called once per frame
  void Update()
  {
    manageSkyboxButtonState();
  }
  
  void manageSkyboxButtonState()
  {
    // get current skybox
    string currSkyBox = viewManager.currentSkybox;

    // compare current skybox name with each name in skybox list
    for (int i = 0; i < skyboxInfo.Length; i++)
    {
      string skybox = skyboxInfo[i].name;
      if (currSkyBox.Equals(skybox))
      {
        Text text;
        text = buttons[i].transform.GetChild(0).GetComponent<Text>();
        text.fontStyle = FontStyle.Bold;
        text.fontSize = fontSizeSelected;
      }
      else
      {
        Text text;
        text = buttons[i].transform.GetChild(0).GetComponent<Text>();
        text.fontStyle = FontStyle.Normal;
        text.fontSize = fontSize;
      }
    }
  }

}
