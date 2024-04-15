
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSwordSItem : MonoBehaviour, IPointerClickHandler
{


    public Image image;
    public Image selectedImage;
    public string swordName;

    public void ChangeImage(Sprite newImage)
    {
        image.sprite = newImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (swordName != PlayerAccount.SelectedWeapone)
            PlayerAccount.SelectedWeapone = swordName;

    }

    private void Update()
    {
        if (swordName == null)
        {
            return;
        }
        if (swordName == PlayerAccount.SelectedWeapone)
        {
            selectedImage.color = Color.black.WithAlpha(0.5f);
        }
        else
        {
            selectedImage.color = Color.black.WithAlpha(0);
        }
    }
}
