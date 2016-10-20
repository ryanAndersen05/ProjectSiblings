using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ColliderOptimization : MonoBehaviour {
    void Start()
    {
        List<PolyShape> polyShapes = getPolygonShapes();
        constructPolygonColliders(polyShapes);
        Destroy(this);
    }

    bool optimizePolygons(List<PolyShape> polygonShapes)
    {
        for (int i = 0; i < polygonShapes.Count - 1; i++)
        {
            for (int j = i + 1; j < polygonShapes.Count; j++)
            {
                PolyShape p1 = polygonShapes[i];
                PolyShape p2 = polygonShapes[j];
            }
        }
        return false;
    }

    void constructPolygonColliders(List<PolyShape> polyShapes)
    {
        foreach (PolyShape p in polyShapes)
        {

            PolygonCollider2D pCollider = this.gameObject.AddComponent<PolygonCollider2D>();
            pCollider.points = p.getVectorPoints();
        }
    }

    List<PolyShape> getPolygonShapes()
    {
        List<PolyShape> polygonShapes = new List<PolyShape>();
        BoxCollider2D[] boxColliders = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D b in boxColliders)
        {
            polygonShapes.Add(new PolyShape(getBoxColliderPoints(b)));
            Destroy(b);
        }
        return polygonShapes;
    }

    Vector2[] getBoxColliderPoints(BoxCollider2D b)
    {
        Vector3 min = b.bounds.min;
        Vector3 max = b.bounds.max;
        Vector2[] vPoints = new Vector2[4];
        float minX = min.x - transform.position.x;
        float minY = min.y - transform.position.y;
        float maxX = max.x - transform.position.x;
        float maxY = max.y - transform.position.y;
        vPoints[0] = new Vector2(minX, maxY);
        vPoints[1] = new Vector2(maxX, maxY);
        vPoints[2] = new Vector2(maxX, minY);
        vPoints[3] = new Vector2(minX, minY);
        foreach (Vector2 v in vPoints)
        {
            print(v);
        }
        return vPoints;
    }
//*******************************************************
    private class PolyShape
    {
        public List<PolyPoint> polyPoints = new List<PolyPoint>();
        public List<PolyVector> polyVectors = new List<PolyVector>();

        public PolyShape(Vector2[] points)
        {

            foreach (Vector2 v in points)
            {
                polyPoints.Add(new PolyPoint(v.x, v.y));
            }

            for (int i = 0; i < polyPoints.Count; i++)
            {
                polyVectors.Add(new PolyVector(polyPoints[i], polyPoints[(i + 1) % polyPoints.Count]));
            }
        }

        public Vector2[] getVectorPoints()
        {
            Vector2[] vecPoints = new Vector2[polyPoints.Count];
            for (int i = 0; i < polyPoints.Count; i++)
            {
                vecPoints[i] = new Vector2(polyPoints[i].x, polyPoints[i].y);
            }
            return vecPoints;
        }

        public PolyVector comparePolyShape(PolyShape p)
        {
            
            foreach (PolyVector v1 in p.polyVectors)
            {
                foreach (PolyVector v2 in this.polyVectors)
                {
                    if (v2.compareVector(v1))
                    {
                        return v1;
                    }
                }
            }
            return null;
        }

        PolyShape combineShape2Point(PolyShape p, PolyVector v)
        {
            List<PolyPoint> newPoints = new List<PolyPoint>();
            int i = 0;
            PolyPoint[] p1Points = p.polyPoints.ToArray();
            PolyPoint[] p2Points = polyPoints.ToArray();
            while (!v.containsPolyPoint(p1Points[i]) && i < p1Points.Length)
            {
                newPoints.Add(p1Points[i]);
                i++;
            }
            int j = 0;
            while (!p1Points[i].comparePoint(p2Points[j]))
            {
                j++;
            }


            return null;
        }

        public static PolyShape optimizePolyShape(PolyShape p1, PolyShape p2)
        {
            PolyVector v = p1.comparePolyShape(p2);
            if (v != null)
            {
                List<Vector2> newPoints = new List<Vector2>();

                
            }
            return null;
        }
    }
//******************************************************
    private class PolyPoint
    {
        public float x;
        public float y;

        public PolyPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public PolyPoint() : this(0, 0)
        {

        }

        public bool comparePoint(PolyPoint p)
        {
            if (Mathf.Abs(p.x - x) > .01f) return false;
            if (Mathf.Abs(p.y - y) > .01f) return false;
            return true;
        }

        public Vector2 toVector()
        {
            return new Vector2(x, y);
        }
    }
//*****************************************************
    private class PolyVector
    {
        public PolyPoint p1;
        public PolyPoint p2;

        public PolyVector(PolyPoint p1, PolyPoint p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public PolyVector() : this(new PolyPoint(), new PolyPoint())
        {

        }

        public bool compareVector(PolyVector v)
        {
            if (v.p1.comparePoint(p1) && v.p2.comparePoint(p2)) return true;
            if (v.p1.comparePoint(p2) && v.p2.comparePoint(p1)) return true;
            return false;
        }

        public bool containsPolyPoint(PolyPoint p)
        {
            if (this.p1.comparePoint(p)) return true;
            if (this.p2.comparePoint(p)) return true;
            return false;
        }
    }
}
