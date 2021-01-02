using UnityEngine;
using UnityEngine.EventSystems;

public class LevelContentScroll : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject[] _pagesWithLevels;
    [SerializeField] private GameObject _content;
    [SerializeField] private float _deltaSwipe;

    private Vector3[] _positionsOfPages;
    private RectTransform _contentRect;

    private Vector2 _tapPoint;
    private Vector2 _endPoint;
    private int _quaintityPages;

    public static int SelectedPage;

    private void Start()
    {
        _contentRect = _content.GetComponent<RectTransform>();
        if (_pagesWithLevels == null || _pagesWithLevels.Length == 0)
            return;

        _positionsOfPages = new Vector3[_pagesWithLevels.Length];
        for (var i = 0; i < _pagesWithLevels.Length; ++i)
        {
            _positionsOfPages[i] = -_pagesWithLevels[i].transform.localPosition;
        }
        _quaintityPages = _positionsOfPages.Length;

        ChangePage();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _tapPoint = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _endPoint = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_tapPoint.x - _endPoint.x >= _deltaSwipe)
        {
            NextPage();
        }
        else if (_endPoint.x - _tapPoint.x >= _deltaSwipe)
        {
            PreviousPage();
        }
    }
    private void ChangePage() => _contentRect.anchoredPosition = _positionsOfPages[SelectedPage];
    private void NextPage()
    {
        if (SelectedPage == _quaintityPages - 1)
            return;

        ++SelectedPage;

        ChangePage();
    }
    
    private void PreviousPage()
    {
        if (SelectedPage == 0)
            return;

        --SelectedPage;
        ChangePage();
    }
}
