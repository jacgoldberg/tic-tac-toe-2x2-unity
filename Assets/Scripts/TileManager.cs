using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];
    public Text swordText;
    public Text shieldText;
    public GameObject reset;
    public GameObject quit;

    private int swordScore;
    private int shieldScore;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
    }

    public void ChangePlayer()
    {
        CheckForWinner();

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public void CheckForWinner()
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            reset.SetActive(true);
            quit.SetActive(true);
            Debug.Log("Winner: " + CurrentPlayer);
            if (CurrentPlayer == Owner.Sword)
            {
                swordScore++;
                swordText.text = "Sword Score: " + swordScore;
            }else
            {
                shieldScore++;
                shieldText.text = "Shield Score: " + shieldScore;
            }
            won = false;
        }

        return;
    }

    public void ResetGame()
    {
        reset.SetActive(false);
        for(int i = 0; i < 9; i++)
        {
            Tiles[i].GetComponent<SpriteRenderer>().color = Color.white;
            Tiles[i].owner = Owner.None;
            Debug.Log("Tile: " + i + " = " + Tiles[i].owner);
        }
        
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
