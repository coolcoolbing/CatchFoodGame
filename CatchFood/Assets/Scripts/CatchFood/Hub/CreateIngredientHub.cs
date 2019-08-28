using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIngredientHub : MonoBehaviour
{
    public Transform CreateIngredientLeftPoint;
    public Transform CreateIngredientRightPoint;

    public GameObject ingredientPrefab; //食材的预制体

    [Tooltip("要生成的食材的图片")]
    public Sprite[] ingredients;

    [Tooltip("每种食材的下落速度")]
    public int[] fallSpeeds;

    private int ingredientsCount;
    private float leftRightWidth;  //生成点左右两点的宽度
    void Start()
    {
        leftRightWidth =Mathf.Abs( CreateIngredientLeftPoint.position.x - CreateIngredientRightPoint.position.x);
        ingredientsCount = ingredients.Length;
        StartCreate();
    }

    /// <summary>
    /// 开始生成食材
    /// </summary>
    public void StartCreate()
    {
        InvokeRepeating("CreateIngredient", 0, 1);
    }

    void CreateIngredient()
    {
        int r=Random.Range(0, ingredientsCount);
        float w= Random.Range(0,leftRightWidth);

        var g = Instantiate(ingredientPrefab,CreateIngredientLeftPoint.position+new Vector3(w,0,0),new Quaternion());

        g.name = ingredients[r].name;
        g.GetComponent<SpriteRenderer>().sprite= ingredients[r];
        g.GetComponent<ingredient>().fallSpeed = fallSpeeds[r];

        Destroy(g,5);
    }
}
