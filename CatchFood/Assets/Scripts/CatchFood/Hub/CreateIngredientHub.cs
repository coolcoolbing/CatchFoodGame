using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchFood
{
    public class CreateIngredientHub : MonoBehaviour
    {
        public Transform CreateIngredientLeftPoint;
        public Transform CreateIngredientRightPoint;

        public GameObject ingredientPrefab; //食材的预制体
        [Tooltip("生成食材所要挂的父物体")] public Transform ingredientsParent;

        [Tooltip("要生成的食材的图片")]
        public Sprite[] ingredients;

        [Tooltip("每种食材的下落速度")]
        public int[] fallSpeeds;

        private int ingredientsCount;
        private float leftRightWidth;  //生成点左右两点的宽度
        void Start()
        {
            leftRightWidth = Mathf.Abs(CreateIngredientLeftPoint.position.x - CreateIngredientRightPoint.position.x);
            ingredientsCount = ingredients.Length;
        }

        /// <summary>
        /// 随机生成食材
        /// </summary>
        public void CreateIngredient()
        {
            int r = Random.Range(0, ingredientsCount);
            float w = Random.Range(0, leftRightWidth);

            var g = Instantiate(ingredientPrefab, CreateIngredientLeftPoint.position + new Vector3(w, 0, 0), new Quaternion(), ingredientsParent);

            g.name = ingredients[r].name;
            g.GetComponent<SpriteRenderer>().sprite = ingredients[r];
            g.GetComponent<ingredient>().fallSpeed = fallSpeeds[r];
        }

        /// <summary>
        /// 游戏结束时销毁所有还在下落的食材
        /// </summary>
        public void DestroyAllFallingIngredients()
        {
            //销毁父物体下的子物体
            for(int i=0;i<ingredientsParent.childCount; i++)
            {
                Destroy(ingredientsParent.GetChild(i).gameObject);
            }
        }
    }
}
