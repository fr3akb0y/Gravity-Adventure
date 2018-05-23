using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Text TooltipShower;
    public string Tooltip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipShower.text = Tooltip;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipShower.text = "";
    }
}
