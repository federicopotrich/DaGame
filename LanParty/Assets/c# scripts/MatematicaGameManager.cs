using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatematicaGameManager : MonoBehaviour
{
    public ArrayList matrix;
    public int[] row;

    public GameObject [] cells;

    public Sprite [] numbers;
    // Start is called before the first frame update
    void Start()
    {

        matrix = new ArrayList(5);
        
            row = new int[]{1, 1, 1, 1, 1};
            matrix.Add(row);
            row = new int[]{2, 2, 2, 2, 2};
            matrix.Add(row);
            row = new int[]{3, 3, 3, 3, 3};
            matrix.Add(row);
            row = new int[]{4, 4, 4, 4, 4};
            matrix.Add(row);
            row = new int[]{5, 5, 5, 5, 5};
            matrix.Add(row);

            for(int j = 0; j < 5000; j++){       
                int col = Random.Range(0, 5);
                int row = Random.Range(0, 5);
                int col2 = Random.Range(0, 5);
                int row2 = Random.Range(0, 5);

                int tmp = ((int[]) matrix[col]) [row];
                ((int[]) matrix[col]) [row] = ((int[]) matrix[col2]) [row2];
                ((int[]) matrix[col2]) [row2] = tmp;
            }
            
        
        int k = 0;
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){       
                cells[k].AddComponent<cell>();
                cells[k].GetComponent<cell>().value = ((int[])(matrix[i]))[j];
                cells[k].GetComponent<cell>().row = j;
                cells[k].GetComponent<cell>().col = i;
                cells[k].GetComponent<UnityEngine.UI.Image>().sprite = numbers[((int[])(matrix[i]))[j]-1];
                k++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class cell : MonoBehaviour
{
    public int col;
    public int row;
    public int value;
}