
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreSwordSItem : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    public Image selectedImage;
    public string swordName;
    public bool isSold;

    public void ChangeImage(Sprite newImage)
    {
        image.sprite = newImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (StoreCanvas.selectedStoreSwordSItem == null || swordName != StoreCanvas.selectedStoreSwordSItem.swordName)
            StoreCanvas.selectedStoreSwordSItem = this;
        else
            StoreCanvas.selectedStoreSwordSItem = null;
    }

    private void Update()
    {
        if (swordName == null)
        {
            return;
        }
        else if (isSold)
        {
            image.color = Color.green.WithAlpha(0.5f);
        }
        if (StoreCanvas.selectedStoreSwordSItem != null && swordName == StoreCanvas.selectedStoreSwordSItem.swordName)
        {
            selectedImage.color = Color.black.WithAlpha(0.5f);
        }
        else
        {
            selectedImage.color = Color.black.WithAlpha(0);
        }
    }
}
