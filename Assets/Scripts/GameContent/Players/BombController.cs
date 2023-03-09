
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BombController : MonoBehaviour
{
    public GameObject bombPrefab;
    public KeyCode input = KeyCode.Space;
    public float bombTime;
    public LayerMask explosionMask;
    private int bombsRemaining;
    private float bombRegenTime;

    public Explosion explPrefab;
    public float duration = 1f;
    public int radius;

    public Destructable destructablePrefab;
    public Tile tile;


    private void OnEnable()
    {
        bombsRemaining = 1;
        bombRegenTime = 5f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(input) && bombsRemaining > 0) 
        {
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);

        GameObject bomb = Instantiate(bombPrefab,pos, Quaternion.identity);
        bombsRemaining--;


        yield return new WaitForSeconds(bombTime);

        pos = bomb.transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);
        Explosion expl = Instantiate(explPrefab, pos, Quaternion.identity);
        expl.BombStageRender(expl.bombBeginning);
        Destroy(expl.gameObject, duration);

        Explode(pos, Vector2.up, radius);
        Explode(pos, Vector2.down, radius);
        Explode(pos, Vector2.left, radius);
        Explode(pos, Vector2.right, radius);

        Destroy(bomb);
        bombsRemaining++;
        
    }

    private void Explode(Vector2 explosionPosition, Vector2 dir, int radius)
    {
        if(radius <= 0)
        {
            return;
        }

        explosionPosition += dir;
        if(Physics2D.OverlapBox(explosionPosition, Vector2.one / 2f, 0f, explosionMask))
        {
                return;
        }
                Explosion explosion = Instantiate(explPrefab, explosionPosition, Quaternion.identity);
                explosion.BombStageRender(radius > 1 ? explosion.bombMiddle : explosion.bombEnding);
                explosion.SetBombDirection(dir);
                Destroy(explosion.gameObject, duration);
                Explode(explosionPosition, dir, radius - 1);
    }

    private void BombCollision(Collider2D cd)
    {
        if(cd.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            cd.isTrigger = false;
        }
    }
}
