using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
 
    enum State
    {
        allies,
        enemies,
        selecting
    }
    struct enemyConfig
    {
        int quantity;


    }

    private Battle_Options bo;
    private State state;

    [SerializeField]
    private SpriteRenderer selectionArrow;
    
    [SerializeField]
    public List<EnemyRobot> enemies;
    private int enemiesIndex;
    
    void Start()
    {
        bo = GetComponentInChildren<Battle_Options>();        
        Vector3 origin = transform.position;
        int x = 1;
        for (var i = 0; i < enemies.Count;i++)
        {
            var position = new Vector3(origin.x,origin.y,origin.z);
            position.x += 5*x++;
            enemies[i] = Instantiate<EnemyRobot>(enemies[i],position,new Quaternion());
        }

        enemiesIndex = 0;
        FlipBattleOptions();
        state = State.selecting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.allies:
                if (Controller.Key(KeyCode.E))
                {
                    StartCoroutine(bo.NextOption());
                }
                if (Controller.Key(KeyCode.Q))
                {
                     StartCoroutine(bo.PrevOption());
                }
                if (Controller.Key(KeyCode.Space))
                {
                    state = State.selecting;
                    FlipBattleOptions();
                    selectionArrow.enabled = true;
                }

                break;

            case State.selecting:

                if (Controller.Key(KeyCode.D))
                {
                    enemiesIndex++;
                    enemiesIndex = enemiesIndex >= enemies.Count ? 0 : enemiesIndex;
                    var pos = enemies[enemiesIndex].transform.position;
                    pos.y += 5;
                    selectionArrow.transform.position = pos;
                }
                if (Controller.Key(KeyCode.A))
                {
                    enemiesIndex--;
                    enemiesIndex = enemiesIndex < 0 ? enemies.Count-1 : enemiesIndex;
                    var pos = enemies[enemiesIndex].transform.position;
                    pos.y += 5;
                    selectionArrow.transform.position = pos;
                }
                if (Controller.Key(KeyCode.Space))
                {

                }
                if (Controller.Key(KeyCode.LeftShift))
                {
                    state = State.allies;
                    selectionArrow.enabled = false;
                    FlipBattleOptions();
                }
                break;

        }
    }

   

    private void FlipBattleOptions()
    {
      GetComponentsInChildren<MeshRenderer>()
            .ToList()
            .ForEach(x => x.enabled = !x.enabled);        
    }
}
