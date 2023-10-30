using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrCircle : MonoBehaviour
{
    public float behaveTimer;

    public LineRenderer lr;

    public Vector2 gridsize;

    public int gridGap;

    float counter;

    public int[,] matrix = new int[0, 0];

    Vector2 lastPos;

    public Line line;

    public int currentPathNumber;

    public bool stop = false;

    [System.Serializable]
    public class Line
    {
        public Sprite whiteImg;
        public Material material;
        public float sizeMultiplier;
        public GameObject parent;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            stop = !stop;
        }
        if(!stop)
        {
            counter += Time.deltaTime;

            if (counter > behaveTimer)
            {
                //CreateLineWithLineRenderer();
                CreateLineWithSprite();
                counter = 0;
            }
        }
    }

    void CreateLineWithSprite()
    {
        int s = Random.Range(0, 4);

        lastPos = transform.position;

        switch (s)
        {
            //up
            case 0:
                if (transform.position.y + gridGap < gridsize.y / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + gridGap);
                    matrix[(int)(transform.position.x + gridsize.x / 2), (int)(-transform.position.y + gridsize.y / 2)]++;
                    CreateLineSprite(0);
                    currentPathNumber++;
                }
                break;
            //down
            case 1:
                if (transform.position.y - gridGap > -gridsize.y / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - gridGap);
                    matrix[(int)(transform.position.x + gridsize.x / 2), (int)(-transform.position.y + gridsize.y / 2)]++;
                    CreateLineSprite(0);
                    currentPathNumber++;
                }
                break;
            //right
            case 2:
                if (transform.position.x + gridGap < gridsize.x / 2)
                {
                    transform.position = new Vector2(transform.position.x + gridGap, transform.position.y);
                    matrix[(int)(transform.position.x + gridsize.x / 2), (int)(-transform.position.y + gridsize.y / 2)]++;
                    CreateLineSprite(90);
                    currentPathNumber++;
                }
                break;
            //left
            case 3:
                if (transform.position.x - gridGap > -gridsize.x / 2)
                {
                    transform.position = new Vector2(transform.position.x - gridGap, transform.position.y);
                    matrix[(int)(transform.position.x + gridsize.x / 2), (int)(-transform.position.y + gridsize.y / 2)]++;
                    CreateLineSprite(90);
                    currentPathNumber++;
                }
                break;
        }
    }

    void CreateLineSprite(float rotate)
    {
        GameObject newLine = new GameObject();
        newLine.transform.parent = line.parent.transform;
        newLine.transform.position = ((Vector2)transform.position + lastPos) / new Vector2(2,2);
        newLine.AddComponent<SpriteRenderer>();
        newLine.GetComponent<SpriteRenderer>().material = line.material;
        newLine.GetComponent<SpriteRenderer>().sprite = line.whiteImg;
        newLine.transform.localScale = new Vector2(1, line.sizeMultiplier);
        newLine.transform.Rotate(new Vector3(0,0,rotate));
    }

    void CreateLineWithLineRenderer()
    {
        int s = Random.Range(0, 4);

        lastPos = transform.position;

        switch (s)
        {
            //up
            case 0:
                if (transform.position.y + gridGap < gridsize.y / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + gridGap);
                    //CreateLineAndSetMatrix();
                    CreateLine();
                }
                break;
            //down
            case 1:
                if (transform.position.y - gridGap > -gridsize.y / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - gridGap);
                    //CreateLineAndSetMatrix();
                    CreateLine();
                }
                break;
            //right
            case 2:
                if (transform.position.x + gridGap < gridsize.x / 2)
                {
                    transform.position = new Vector2(transform.position.x + gridGap, transform.position.y);
                    //CreateLineAndSetMatrix();
                    CreateLine();
                }
                break;
            //left
            case 3:
                if (transform.position.x - gridGap > -gridsize.x / 2)
                {
                    transform.position = new Vector2(transform.position.x - gridGap, transform.position.y);
                    //CreateLineAndSetMatrix();
                    CreateLine();
                }
                break;
        }
    }

    //Doesnt work currently
    /*void CreateLineAndSetMatrix()
    {
        Vector2 pos = new Vector2();
        Vector2 lastpos = new Vector2();

        /*if (lastpos.x >= 0 && lastpos.y >= 0)
        {
            pos = new Vector2((int)((lastpos.x) / gridGap), (int)((lastpos.y) / gridGap));
        }

        if (lastpos.x <= 0 && lastpos.y >= 0)
        {
            pos = new Vector2(Mathf.Abs((int)((lastpos.x) / gridGap)) + gridsize.x / 2, (int)((lastpos.y) / gridGap));
        }

        if (lastpos.x >= 0 && lastpos.y <= 0)
        {
            pos = new Vector2((int)((lastpos.x) / gridGap), Mathf.Abs((int)((lastpos.y) / gridGap)) + gridsize.y / 2);
        }

        if (lastpos.x <= 0 && lastpos.y <= 0)
        {
            pos = new Vector2(Mathf.Abs((int)((lastpos.x) / gridGap)) + gridsize.x / 2, Mathf.Abs((int)((lastpos.y) / gridGap)) + gridsize.y / 2);
        }

        if (transform.position.x >= 0 && transform.position.y >= 0)
        {
            pos = new Vector2((int)((transform.position.x) / gridGap), (int)((transform.position.y) / gridGap));
        }

        if(transform.position.x <= 0 && transform.position.y >= 0)
        {
            pos = new Vector2(Mathf.Abs((int)((transform.position.x) / gridGap)) + gridsize.x / 2, (int)((transform.position.y) / gridGap));
        }

        if (transform.position.x >= 0 && transform.position.y <= 0)
        {
            pos = new Vector2((int)((transform.position.x) / gridGap), Mathf.Abs((int)((transform.position.y) / gridGap)) + gridsize.y / 2);
        }

        if (transform.position.x <= 0 && transform.position.y <= 0)
        {
            pos = new Vector2(Mathf.Abs((int)((transform.position.x) / gridGap)) + gridsize.x / 2, Mathf.Abs((int)((transform.position.y) / gridGap)) + gridsize.y / 2);
        }
        Debug.Log(pos);

        Debug.Log(matrix[(int)pos.x, (int)pos.y]);
        if (matrix[(int)pos.x, (int)pos.y] == 0)
        {
            lr.positionCount += 2;
            lr.SetPosition(lr.positionCount - 2, lastPos);
            lr.SetPosition(lr.positionCount - 1, transform.position);
        }/*else if(matrix[(int)pos.x, (int)pos.y] != 0 && matrix[(int)lastpos.x, (int)lastpos.y] != 0)
        {
        }
        matrix[(int)pos.x, (int)pos.y]++;
    }*/

    void CreateLine()
    {
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, transform.position);
        matrix[(int)(transform.position.x + gridsize.x / 2), (int)(-transform.position.y + gridsize.y / 2)]++;
        counter = 0;
        currentPathNumber++;
    }

    public void SetMatrix()
    {
        matrix = new int[(int)gridsize.y, (int)gridsize.x];
        for(int i = 0; i < gridsize.y; i++)
        {
            for(int j = 0; j < gridsize.x; j++)
            {
                matrix[i, j] = 0;
            }
        }
    }
}
