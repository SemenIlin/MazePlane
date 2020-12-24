using System.Collections;
using System.Collections.Generic;
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
    private int _selectedPage;
    private int _quaintityPages;

    private void Start()
    {
        _selectedPage = 0;
        _contentRect = _content.GetComponent<RectTransform>();
        if (_pagesWithLevels == null || _pagesWithLevels.Length == 0)
            return;

        _positionsOfPages = new Vector3[_pagesWithLevels.Length];
        for (var i = 0; i < _pagesWithLevels.Length; ++i)
        {
            _positionsOfPages[i] = -_pagesWithLevels[i].transform.localPosition;
        }
        _quaintityPages = _positionsOfPages.Length;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _tapPoint = Input.mousePosition;
        Debug.Log(_tapPoint);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _endPoint = Input.mousePosition;
        Debug.Log(_endPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_tapPoint.x - _endPoint.x >= _deltaSwipe)
        {
            if (_selectedPage == _quaintityPages - 1)
                return;

            _selectedPage++;
            _contentRect.anchoredPosition = _positionsOfPages[_selectedPage];
        }
        else if (_endPoint.x - _tapPoint.x >= _deltaSwipe)
        {
            if (_selectedPage == 0)
                return;

            _selectedPage--;
            _contentRect.anchoredPosition = _positionsOfPages[_selectedPage];
        }
    }
}
