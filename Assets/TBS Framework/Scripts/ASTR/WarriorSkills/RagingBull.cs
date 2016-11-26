using UnityEngine;
using System.Collections.Generic;

public class RagingBull : Skill
{

    public override string Name
    {
        get { return "Raging Bull"; }
        set { }
    }

    public override int MinRange
    {
        get { return 2; }
        set { base.MinRange = value;  }
    }

    public override int MaxRange
    {
        get { return 4; }
        set { base.MaxRange = value; }
    }

    public override int MinDamage
    {
        get { return 15; }
        set { base.MinDamage = value; }
    }

    public override int MaxDamage
    {
        get { return 19; }
        set { base.MaxDamage = value; }
    }

    public override int Cooldown
    {
        get { return 2; }
        set { }
    }

    public override int CurrentCooldown
    {
        get { return 0; }
        set { }
    }

    public override bool CanTargetEmptyCell
    {
        get { return false; }
        set { }
    }

    public override bool CanTargetEnemies
    {
        get { return true; }
        set { }
    }

    public override bool CanTargetAllies
    {
        get { return false; }
        set { }
    }

    public override bool AlignmentNeeded
    {
        get { return true; }
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

    public override void Apply(Unit caster, Unit receiver)
    {
        // Comparer les positions de caster et receiver
        // Déplacer caster au contact de receiver
        // Appliquer les dégâts si contact (dash < 3 cases)
    }

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

        // **TODO**
        // Comparer les positions de caster et receiver
        // Déplacer caster au contact de receiver
        // Appliquer les dégâts si contact (dash < 3 cases)

        caster.ActionPoints--;
        SetCooldown();
    }

    public override void Apply (Unit caster, List<Cell> cells, CellGrid cellGrid){}
}