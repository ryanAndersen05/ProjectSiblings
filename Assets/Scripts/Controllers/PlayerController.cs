using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject[] playableCharacters = new GameObject[2];
    public bool disableControls;
    public int currentPlayer = 0;
    MovementMechanics[] mMechanics;
    JumpMechanics[] jMechanics;
    AttackMechanics[] aMechanics;
    ArcherMechanics[] archMechanics;
    BufferedInputs bInputs;

    void Start()
    {
        mMechanics = new MovementMechanics[playableCharacters.Length];
        jMechanics = new JumpMechanics[playableCharacters.Length];
        aMechanics = new AttackMechanics[playableCharacters.Length];
        archMechanics = new ArcherMechanics[playableCharacters.Length];
        for (int i = 0; i < playableCharacters.Length; i++)
        {
            mMechanics[i] = playableCharacters[i].GetComponent<MovementMechanics>();
            jMechanics[i] = playableCharacters[i].GetComponent<JumpMechanics>();
            aMechanics[i] = playableCharacters[i].GetComponent<AttackMechanics>();
            archMechanics[i] = playableCharacters[i].GetComponent<ArcherMechanics>();
            playableCharacters[i].transform.parent = null;
        }
        bInputs = new BufferedInputs();
        bInputs.addInputNode("Jump");
        bInputs.addInputNode("Action");
        bInputs.addInputNode("Attack", .2f);
        bInputs.addInputNode("Projectile");
    }

    void Update()
    {
        bInputs.resetBuffer();
        updateCurrentPlayer();
        updateAllPlayers();
        bInputs.updateInputs();
    }

    void updateCurrentPlayer()
    {
        if (mMechanics[currentPlayer] != null)
        {
            mMechanics[currentPlayer].setHorizontalInput(Input.GetAxisRaw("Horizontal"));
        }
        if (jMechanics[currentPlayer] != null)
        {
            bInputs.cancelBuffer("Jump", jMechanics[currentPlayer].activateJump(bInputs.isActive("Jump")));
        }
    }

    void updateAllPlayers()
    {
        for (int i = 0; i < playableCharacters.Length; i++)
        {
            if (archMechanics[i] != null)
            {
                archMechanics[i].chargeBow(Input.GetButton("Projectile"));
            }
            if (aMechanics[i] != null)
            {
                aMechanics[i].attack(bInputs.isActive("Attack"));
            }
        }
    }

    public Transform getCurrentPlayer()
    {
        return playableCharacters[currentPlayer].transform;
    }
}
