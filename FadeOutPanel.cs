using UnityEngine;
using UnityEngine.UI;

public class FadeOutPanel : MonoBehaviour {

  public GameObject fadePanelPrefab;
  public float fadeTime = 1.5f;

	// Use this for initialization
	void Start() {}
	
  public void FadePanel()
  {
    GameObject fadePanel = (GameObject)Instantiate(fadePanelPrefab);
    // set clone as child of gameobject
    fadePanel.transform.SetParent(gameObject.transform, false);
    Image image = fadePanel.GetComponent<Image>();
    // cross fade panel
    image.CrossFadeAlpha(0, fadeTime, false);
    // destroy clone when fade has ended
    Destroy(fadePanel, fadeTime);
  }
  
}
