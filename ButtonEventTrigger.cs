using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEventTrigger : MonoBehaviour {
  
  protected MusicManager manager;
  protected Button myButton;
  protected FadeOutPanel fadePanel;

  // TODO: refactor as interface
  protected virtual void Awake()
  {
    var musicManager = GameObject.FindGameObjectWithTag("MusicManager");
    manager = musicManager != null ? musicManager.GetComponent<MusicManager>() : null;

    var overlayCanvas = GameObject.FindGameObjectWithTag("OverlayCanvas");
    fadePanel = overlayCanvas != null ? overlayCanvas.GetComponent<FadeOutPanel>() : null;
  }

	// Use this for initialization
	protected virtual void Start () 
  {
    myButton = GetComponent<Button>();
	  EventTrigger trigger = GetComponent<EventTrigger>();
    
    EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
    pointerEnter.eventID = EventTriggerType.PointerEnter;
    pointerEnter.callback.AddListener( ( data ) => { OnPointerEnterDelegate( (PointerEventData)data ); } );
    trigger.triggers.Add( pointerEnter );

    EventTrigger.Entry pointerDown = new EventTrigger.Entry();
    pointerDown.eventID = EventTriggerType.PointerDown;
    pointerDown.callback.AddListener( ( data ) => { OnPointerDownDelegate( (PointerEventData)data ); } );
    trigger.triggers.Add( pointerDown );

	}

  protected virtual void OnPointerEnterDelegate(PointerEventData data)
  {
    if (myButton.interactable && manager)
    {
      manager.PlayAudioClip(1);

    }
  }

  protected virtual void OnPointerDownDelegate(PointerEventData data)
  {
    if (myButton.interactable && manager)
    {
      manager.PlayAudioClip(2);
    }

    if (fadePanel)
    {
      fadePanel.FadePanel();
    }
  }

}
