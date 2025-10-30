using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UICursorManager : MonoBehaviour
{
    [SerializeField] Sprite _crosshair;
    [SerializeField] Sprite _arrow;
    [SerializeField] RectTransform[] _uiPanels;
    [SerializeField] Canvas _uiCanvas;

    private Image _cursor;
    private Canvas _cachedCanvas;

    void Awake()
    {
        _cursor = GetComponentInChildren<Image>();
        _cachedCanvas = _uiCanvas != null ? _uiCanvas : GetComponentInParent<Canvas>();
        HideSystemCursor(true);
        SetCursorSprite(_crosshair);
    }

    void OnEnable() => HideSystemCursor(true);

    void OnDisable() => HideSystemCursor(false);

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus && isActiveAndEnabled)
            HideSystemCursor(true); // Editor may restore the cursor when focus changes
    }

    void Update()
    {
        if (_cursor == null || UIManager.Instance == null) return;

        Vector2 pointerPosition = UIManager.Instance.UIInputActions.UI.Point.ReadValue<Vector2>();
        _cursor.rectTransform.position = pointerPosition;

        bool overPanel = IsPointerOverPanel(pointerPosition);
        SetCursorSprite(overPanel ? _arrow : _crosshair);
    }

    private bool IsPointerOverPanel(Vector2 screenPoint)
    {
        if (_uiPanels == null || _uiPanels.Length == 0) return false;

        Camera eventCamera = _cachedCanvas != null ? _cachedCanvas.worldCamera : null;
        for (int i = 0; i < _uiPanels.Length; i++)
        {
            RectTransform panel = _uiPanels[i];
            if (panel == null) continue;

            if (RectTransformUtility.RectangleContainsScreenPoint(panel, screenPoint, eventCamera))
                return true;
        }

        return false;
    }

    private void SetCursorSprite(Sprite sprite)
    {
        if (_cursor == null || sprite == null) return;

        if (_cursor.sprite != sprite)
        {
            _cursor.sprite = sprite;
            _cursor.SetNativeSize();
        }
    }

    private static void HideSystemCursor(bool hide)
    {
        Cursor.visible = !hide;
        Cursor.lockState = hide ? CursorLockMode.Confined : CursorLockMode.None;
    }
}
