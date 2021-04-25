using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VJHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jsContainer;
    private Image joystick;
    public bool isDrag;
    public Vector2 InputDirection;

    void Start()
    {

        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector2.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;
        isDrag = true;
        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector2(x, y);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector2(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);

    }

    public void OnPointerDown(PointerEventData ped)
    {

        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        isDrag = false;
        InputDirection = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
    public void resetO()
    {
        isDrag = false;
        InputDirection = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
    public void changeVJ(Vector2 v)
    {
        InputDirection = v;
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector2(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);
    }
}