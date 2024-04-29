using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;

    public List<Vector2> GetPositions()
    {
        List<Vector2> positions = new List<Vector2>();
        for (int i = 0; i < _renderer.positionCount; i++)
        {
            positions.Add(_renderer.GetPosition(i));
        }
        return positions;
    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos)) return;

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    public void SetPositions(Vector2[] positions)
    {
        _renderer.positionCount = positions.Length;
        for (int i = 0; i < positions.Length; i++)
        {
            _renderer.SetPosition(i, positions[i]);
        }
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManagerScript.Resolution;
    }
}

//
//
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using UnityEngine;
//
//public class Line : MonoBehaviour
//{
//
//    [SerializeField]
//    private LineRenderer _renderer;
//
//    void Start()
//    {
//        
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        
//    }
//
//    public void SetPosition (Vector2 pos)
//    {
//        if (!CanAppend(pos)) return;
//
//        _renderer.positionCount++;
//        _renderer.SetPosition(_renderer.positionCount -1, pos);
//    }
//
//    private bool CanAppend (Vector2 pos)
//    {
//        if (_renderer.positionCount == 0) return true;
//        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManagerScript.Resolution;
//    }
//    
//}
//