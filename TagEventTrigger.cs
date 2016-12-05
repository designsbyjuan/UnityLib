using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TagEventTrigger : ButtonEventTrigger {

  protected void Awake()
  {
    base.Awake();
  }
  // Use this for initialization
  protected void Start () 
  {
    base.Start();
  } 

  protected override void OnPointerDownDelegate(PointerEventData data) { /* do nothing */ }

}
