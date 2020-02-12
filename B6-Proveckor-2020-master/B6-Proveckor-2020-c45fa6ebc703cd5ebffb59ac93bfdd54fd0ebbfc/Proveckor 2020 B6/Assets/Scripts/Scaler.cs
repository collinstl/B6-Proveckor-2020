using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scaler : MonoBehaviour
{
    public RectTransform[] UIComponents;
    float sizeX;
    float sizeY;
    float posX;
    float posY;

    public List<Vector2> sizeList = new List<Vector2>();
    public List<Vector2> posList = new List<Vector2>();

    
    private void Update()
    {       
       PercentageCalculation();         
    }

    void PercentageCalculation()
    {
        if(sizeList.Count < UIComponents.Length && posList.Count < UIComponents.Length)
        for (int i = 0; i < UIComponents.Length; i++)
        {
            RectTransform component = UIComponents[i];
            RectTransform parent = component.parent.gameObject.GetComponent<RectTransform>();

            sizeX = component.sizeDelta.x / parent.sizeDelta.x;
            sizeY = component.sizeDelta.y / parent.sizeDelta.y;

            float edgeOfChildX = component.anchoredPosition.x > 0 ? component.anchoredPosition.x + (component.sizeDelta.x / 2) : component.anchoredPosition.x - (component.sizeDelta.x / 2);
            float edgeOfChildY = component.anchoredPosition.y > 0 ? component.anchoredPosition.y + (component.sizeDelta.y / 2) : component.anchoredPosition.y - (component.sizeDelta.y / 2);
            float edgeOfParentX = component.anchoredPosition.x > 0 ? parent.anchoredPosition.x + (parent.sizeDelta.x / 2) : parent.anchoredPosition.x - (parent.sizeDelta.x / 2);
            float edgeOfParentY = component.anchoredPosition.y > 0 ? parent.anchoredPosition.y + (parent.sizeDelta.y / 2) : parent.anchoredPosition.y - (parent.sizeDelta.y / 2);

            float distanceX = Mathf.Abs(edgeOfChildX - edgeOfParentX);
            float distanceY = Mathf.Abs(edgeOfChildY - edgeOfParentY);
            posX = distanceX / parent.sizeDelta.x;
            posY = distanceY / parent.sizeDelta.y;

            Vector2 size = new Vector2(sizeX, sizeY);
            Vector2 pos = new Vector2(posX, posY);
            sizeList.Add(size);
            posList.Add(pos); 
        }
    }

   
}
