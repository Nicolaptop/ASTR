using UnityEngine;
using System.Collections.Generic;

public class ShoulderBash : Skill
{

    public override string Name
    {
        get { return "Shoulder Bash"; }
        set { }
    }

    public override int MinRange
    {
        get { return 1; }
        set { base.MinRange = value;  }
    }

    public override int MaxRange
    {
        get { return 1; }
        set { base.MaxRange = value; }
    }

    public override int MinDamage
    {
        get { return 17; }
        set { base.MinDamage = value; }
    }

    public override int MaxDamage
    {
        get { return 21; }
        set { base.MaxDamage = value; }
    }

    public override int Cooldown
    {
        get { return 3; }
        set { }
    }

    public override int CurrentCooldown
    {
        get { return 0; }
        set { }
    }

    public override bool CanTargetEmptyCell
    {
        get { return true; }
        set { }
    }

    public override bool CanTargetEnemies
    {
        get { return true; }
        set { }
    }

    public override bool CanTargetAllies
    {
        get { return true; }
        set { }
    }

    public override bool AlignmentNeeded
    {
        get { return false; }
        set { }
    }

    public override int isAoE
    {
        get { return 1; }
        set { }
    }

    public override int AoERange
    {
        get { return 0; }
        set { }
    }

    // **TODO**
    // Comparer les positions du caster et receiver
    // Vérifier s'il y a des obstacles dans l'alignement
    // Vérifier si receiver a le buff "insensible aux cc"
    // Repousser le receiver de 2 cases ou jusqu'à un obstacle
    // Rajouter 3 aux dégâts si obstacle

    public override void Apply(Unit caster, Unit receiver){}

    public override void Apply(Unit caster, Cell receiver, CellGrid cellGrid){}

    public override void Apply (Unit caster, List<Unit> receivers)
    {
        Animator anim = caster.GetComponentInChildren<Animator>();
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);

        foreach (var receiver in receivers)
        {
            int damage = Random.Range(MinDamage, MaxDamage+1);
            caster.DealDamage2(receiver, damage);
        }

        caster.ActionPoints--;
        SetCooldown();
    }

    public override void Apply (Unit caster, List<Cell> cells, CellGrid cellGrid)
    {

        Animator anim = caster.GetComponentInChildren<Animator>();
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);

        foreach (var currentCell in cells)
        {
            if (currentCell.Occupent != null)
            {
                int damage = Random.Range(MinDamage, MaxDamage+1);
                caster.DealDamage2(currentCell.Occupent, damage);
            }
        }

        caster.ActionPoints--;
        SetCooldown();
    }
}