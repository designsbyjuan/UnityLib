using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using VRStandardAssets.Utils;

public class LookDownCanvas : MonoBehaviour {

  private CanvasGroup canvasGroup;
  private UIFader uiFader;
  private CardboardMain main;
  public float UIDistance = 300f;
  public float UIHeight = -400f;
  public float UIRotation = 65f;

  // Use this for initialization
  void Start () {
    uiFader = GetComponent<UIFader>();
    canvasGroup = GetComponent<CanvasGroup>();
    main = FindObjectOfType<CardboardMain>();
  }

  // Update is called once per frame
  void Update()
  {
    // checks if canvas should follow player
    StartCoroutine(FollowPlayer());
  }

  IEnumerator FollowPlayer()
  {
    // check if lookdowncanvas is visible
    if (canvasGroup.alpha <= 0)
      // canvas is not visible, so it should follow the player
      {
        Quaternion offsetRot = Quaternion.AngleAxis(UIRotation, Vector3.right);
        Quaternion playerLookRot = Quaternion.LookRotation(main.ProjectedVector(), Vector3.up);
        // set canvas to player look rotation
        transform.rotation = playerLookRot * offsetRot;
        // set canvas to player position
        transform.position = main.transform.position;
        // set distance from player
        transform.position += main.ProjectedVector() * UIDistance;
        // set height from ground
        transform.position += Vector3.up * UIHeight;
      }
      yield return null;
  }

  public void ShowCanvas()
  {
    StartCoroutine(uiFader.FadeIn());
    canvasGroup.interactable = true;
  }

  public void HideCanvas()
  {
    StartCoroutine(uiFader.FadeOut());
    canvasGroup.interactable = false;
  }
	
}
