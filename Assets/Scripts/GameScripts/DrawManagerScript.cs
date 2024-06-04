using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawManagerScript : MonoBehaviour
{
    [SerializeField] private Line _LinePrefab;
    [SerializeField] private Collider2D _DrawAreaCollider;
    [SerializeField] private int MinimumPoints;
    private Camera _cam;
    private Line _CurrentLine;
    private bool touchActive;

    public delegate void WallHitEvent();
    public static event WallHitEvent WallHit;

    public const float Resolution = .025f;
    public float SimplifyTolerance = 0.05f;

    void Start()
    {
        _cam = Camera.main;
        touchActive = false;
    }

    void Update()
    {
        if (Stats.IsPaused == false && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = _cam.ScreenToWorldPoint(touch.position);

            if (MouseInsideDrawingArea(touchPos))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    touchActive = true;
                    _CurrentLine = Instantiate(_LinePrefab);
                }

                if (touch.phase == TouchPhase.Moved && touchActive)
                {
                    _CurrentLine.SetPosition(touchPos);
                }
            }
            else if (touchActive)
            {
                touchActive = false;
                Destroy(_CurrentLine.gameObject);
                touch.phase= TouchPhase.Canceled;
                if (WallHit != null)
                {
                    WallHit();
                }
            }

            if (touch.phase == TouchPhase.Ended && touchActive)
            {
                SimplifyAndDrawLine();
                touchActive = false;
            }
        }
    }

    private void SimplifyAndDrawLine()
    {
        // Obtener los puntos actuales de la línea
        List<Vector2> currentPoints = _CurrentLine.GetPositions();
        if (currentPoints.Count < MinimumPoints) { Destroy(_CurrentLine.gameObject); }

        // Simplificar la línea
        List<Vector2> simplifiedPoints = SimplifyPositions(currentPoints, SimplifyTolerance);

        // Establecer los puntos simplificados en la línea
        _CurrentLine.SetPositions(simplifiedPoints.ToArray());
    }

    private List<Vector2> SimplifyPositions(List<Vector2> positions, float tolerance)
    {
        // Implementa el algoritmo de Douglas-Peucker aquí
        // Este es solo un esbozo básico, puedes usar una implementación más robusta si es necesario

        List<Vector2> simplified = new List<Vector2>();

        // Aquí es donde aplicas el algoritmo de Douglas-Peucker
        // A continuación se muestra un ejemplo muy básico
        for (int i = 0; i < positions.Count; i++)
        {
            if (i == 0 || i == positions.Count - 1 || Vector2.Distance(positions[i], positions[i - 1]) > tolerance)
            {
                simplified.Add(positions[i]);
            }
        }
        return simplified;
    }

    private bool MouseInsideDrawingArea(Vector2 touchPos)
    {
        return _DrawAreaCollider.OverlapPoint(touchPos);
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//
//public class DrawManagerScript : MonoBehaviour
//{
//    [SerializeField] private Line _LinePrefab;
//    [SerializeField] private Collider2D _DrawAreaCollider;
//    [SerializeField] private int MinimumPoints;
//    private Camera _cam;
//    private Line _CurrentLine;
//    private bool mousePressed;
//
//    public delegate void WallHitEvent();
//    public static event WallHitEvent WallHit;
//
//    public const float Resolution = .025f;
//    public float SimplifyTolerance = 0.05f; 
//
//    void Start()
//    {
//        _cam = Camera.main;
//        mousePressed = false;
//    }
//
//    void Update()
//    {
//        if (Stats.IsPaused == false)
//        {
//            Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
//        
//            if (MouseInsideDrawingArea(mousePos))
//            {
//                if (Input.GetMouseButtonDown(0))
//                {
//                    mousePressed = true;
//                    _CurrentLine = Instantiate(_LinePrefab);
//                }
//
//                if (Input.GetMouseButton(0) && mousePressed == true)
//                {
//                    _CurrentLine.SetPosition(mousePos);
//                }
//            }
//            else if (mousePressed == true)
//            {
//                mousePressed = false;
//                Destroy(_CurrentLine.gameObject);
//
//                if (WallHit!=null)
//                { 
//                    WallHit(); 
//                }
//            }
//
//            if (Input.GetMouseButtonUp(0) && mousePressed==true)
//            {
//                SimplifyAndDrawLine();
//                mousePressed = false;
//            }
//        }
//    }
//
//    private void SimplifyAndDrawLine()
//    {
//        // Obtener los puntos actuales de la línea
//        List<Vector2> currentPoints = _CurrentLine.GetPositions();
//        if (currentPoints.Count < MinimumPoints) { Destroy(_CurrentLine.gameObject); }
//
//        // Simplificar la línea
//        List<Vector2> simplifiedPoints = SimplifyPositions(currentPoints, SimplifyTolerance);
//
//        // Establecer los puntos simplificados en la línea
//        _CurrentLine.SetPositions(simplifiedPoints.ToArray());
//    }
//
//    private List<Vector2> SimplifyPositions(List<Vector2> positions, float tolerance)
//    {
//        // Implementa el algoritmo de Douglas-Peucker aquí
//        // Este es solo un esbozo básico, puedes usar una implementación más robusta si es necesario
//        
//        List<Vector2> simplified = new List<Vector2>();
//
//        // Aquí es donde aplicas el algoritmo de Douglas-Peucker
//        // A continuación se muestra un ejemplo muy básico
//        for (int i = 0; i < positions.Count; i++)
//        {
//            if (i == 0 || i == positions.Count - 1 || Vector2.Distance(positions[i], positions[i - 1]) > tolerance)
//            {
//                simplified.Add(positions[i]);
//            }
//        }
//        return simplified;
//    }
//    private bool MouseInsideDrawingArea (Vector2 mousePos)
//    {
//        return _DrawAreaCollider.OverlapPoint(mousePos);
//    }
//}