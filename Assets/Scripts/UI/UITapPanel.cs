using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITapPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private MeshRenderer _pathRenderer;
    private CardThrow _cardThrow;

    public void Init(MeshRenderer pathRenderer, CardThrow cardThrow)
    {
        _cardThrow = cardThrow;
        _pathRenderer = pathRenderer;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _pathRenderer.enabled = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pathRenderer.enabled = false;
        _cardThrow.Throwing();
    }
}
