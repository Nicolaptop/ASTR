﻿using UnityEngine;
using System.Collections.Generic;

public class TwinDaggers : Skill
{

    public override string Name
    {
        get { return "TwinDaggers"; }
        set { }
    }

    public override string Tooltip
    {
        get
        {
            return "Basic rogue attack. Throw explosives kunais to a cell";
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
        get { return 3; }
        set { base.MaxRange = value; }
    }

    public override int MinDamage
    {
        get { return 17; }
        set { base.MinDamage = value; }
    }

    public override int MaxDamage
    {
        get { return 20; }
        set { base.MaxDamage = value; }
    }

    public override int Cooldown
    {
        get { return 2; } //testing purposes
        set { }
    }

    public override bool CanTargetEmptyCell
    {
        get { return true; }//testing purpose
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
        get { return true; } //testing purpose
        set { }
    }

    public override int isAoE
    {
        get { return 1; } //testing purpose
        set { }
    }

    public override int AoERange
    {
        get { return 1; } //testing purpose
        set { }
    }

    public override void Apply(Unit caster, Unit receiver)
    {
        Animator anim = caster.GetComponentInChildren<Animator>();
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);
        if (caster.Equals(receiver))
        {
            return;
        }
        caster.DealDamage2(receiver);
        receiver.printDamage(caster.AttackFactor);
        caster.ActionPoints--;
        SetCooldown();
    }

    public override void Apply (Unit caster, List<Unit> receivers)
    {
        foreach (var receiver in receivers)
        {
            caster.DealDamage2(receiver);
            receiver.printDamage(caster.AttackFactor);
        }
        SetCooldown();
    }

    public override void Apply (Unit caster, List<Cell> cells, CellGrid cellGrid)
    {
        foreach (var currentCell in cells)
        {
            if (currentCell.Occupent != null)
            {
                currentCell.Occupent.printDamage(caster.AttackFactor);
                caster.DealDamage2(currentCell.Occupent);
            }
        }
        SetCooldown();
    }

    public override void Apply(Unit caster, Cell receiver, CellGrid cellGrid) { return; }
}
