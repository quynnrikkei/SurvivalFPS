using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemyController;

    public float health = 100f; //Current Health of Player and Enemy

    private float maxHealth = 100f;
    //public Image EnemyHealth;

    public bool is_Player, is_Boar, is_Cannibal;

    private bool is_Dead;

    private int scoreValue = 10; //Point when hit enemy

    private EnemyAudio enemyAudio;

    private PlayerStats player_Stats;

    private EnemyHealth enemy_Health;


    void Awake()
    {
        if (is_Boar || is_Cannibal)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            navAgent = GetComponent<NavMeshAgent>();
            enemyController = GetComponent<EnemyController>();
            enemyAudio = GetComponentInChildren<EnemyAudio>();
            enemy_Health = GetComponent<EnemyHealth>();
        }

        if (is_Player)
        {
            player_Stats = GetComponent<PlayerStats>();

        }


    }

    public void ApplyDamage(float damage)
    {
        if (is_Dead)
            return;

        health -= damage;

        if (is_Player)
        {
            player_Stats.Display_HealthStats(health);

        }

        if (is_Cannibal || is_Boar)
        {
            if (enemyController.Enemy_State == EnemyState.PATROL)
            {
                enemyController.chase_Distance = 50f;

                ScoreManager.score += scoreValue; //Point kill enemy

                enemy_Health.Display_HealthEnemy(health);

            }
        }

        if (health <= 0f)
        {
            PlayerDied();

            is_Dead = true;


        }

    }

    private void PlayerDied()
    {
        if (is_Cannibal)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 50f);

            enemy_Anim.enabled = false;
            navAgent.enabled = false;
            enemyController.enabled = false;

            StartCoroutine(DeadSound());

            GameManager.instance.EnemyDied(true);
        }

        if (is_Boar)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemyController.enabled = false;

            enemy_Anim.Dead();

            StartCoroutine(DeadSound());

            GameManager.instance.EnemyDied(false);
        }

        if (is_Player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            GameManager.instance.StopSpawning();

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);

        }

        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }



    void RestartGame()
    {

        SceneManager.LoadScene("Main Menu");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadClip();
    }
}
