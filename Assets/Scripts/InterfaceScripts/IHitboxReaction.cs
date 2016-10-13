using UnityEngine;
using System.Collections;

public interface IHitboxReaction {
    void onHitboxEntered(Hitbox hBox);
    void onHurtboxEntered(Hurtbox hBox);
    void onHitboxExit(Hitbox hBox);
    void onHurtboxExit(Hurtbox hBox);
    void onDefaultEnter(Collider2D collider);
    void onDefaultExit(Collider2D collider);
}
