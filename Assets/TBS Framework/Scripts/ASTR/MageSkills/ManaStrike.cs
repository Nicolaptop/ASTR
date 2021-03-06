using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class ManaStrike : Skill
{

    public override string Name
    {
        get { return "ManaStrike"; }
        set { }
    }
    public override string Tooltip
    {
        get
        {
            return "Mage basic attack. Reduces cooldowns of skills by 1";
        }

        set
        {
            base.Tooltip = value;
        }
    }
    public override int MinRange
    {
        get { return 2; }
        set { base.MinRange = value;  }
    }

    public override int MaxRange
    {
        get { return 5; }
        set { base.MaxRange = value; }
    }

    public override int MinDamage
    {
        get { return 12; }
        set { base.MinDamage = value; }
    }

    public override int MaxDamage
    {
        get { return 15; }
        set { base.MaxDamage = value; }
    }

    public override int Cooldown
    {
        get { return 1; }
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
        get { return false; }
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

    // **TODO** Implémenter la réduction des CDs.

    public override void Apply (Unit caster, List<Unit> receivers, CellGrid cellgrid)
    {
        Animator anim = caster.GetComponentInChildren<Animator>();
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);

        foreach (var receiver in receivers)
        {
            int damage = UnityEngine.Random.Range(MinDamage, MaxDamage+1);
            caster.DealDamage2(receiver, damage);

        }

        foreach (Skill s in caster.Skills)
        {
            s.CurrentCooldown--;
            if (s.CurrentCooldown < 0) s.CurrentCooldown = 0;
        }
        caster.ActionPoints--;
        SetCooldown();
    }

    public override void Apply (Unit caster, List<Cell> cells, CellGrid cellGrid)
    {
    }
}
