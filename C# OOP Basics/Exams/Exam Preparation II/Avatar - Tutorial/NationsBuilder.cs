﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            { "Air", new Nation() },
            { "Water", new Nation() },
            { "Fire", new Nation() },
            { "Earth", new Nation() }
        };

        this.warHistoryRecord = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];

        Bender currentBender = this.GetBender(benderArgs);
        this.nations[benderType].AddBender(currentBender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var monumnetType = monumentArgs[0];

        Monument currentMonument = this.GetMonument(monumentArgs);
        this.nations[monumnetType].AddMonument(currentMonument);
    }

    public string GetStatus(string nationsType)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);

        return sb.ToString();
    }

    public void IssueWar(string nationsType)
    {
        double victoriousPower = this.nations.Max(kvp => kvp.Value.GetTotalPower());

        foreach (var nation in this.nations.Values)
        {
            if (nation.GetTotalPower() != victoriousPower)
            {
                nation.DeclarateDefeat();
            }
        }

        this.warHistoryRecord.Add($"War {this.warHistoryRecord.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord() => string.Join(Environment.NewLine, this.warHistoryRecord);

    private Bender GetBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        var benderName = benderArgs[1];
        var benderPower = int.Parse(benderArgs[2]);
        var benderAuxParam = double.Parse(benderArgs[3]);

        switch (benderType)
        {
            case "Air":
                return new AirBender(benderName, benderPower, benderAuxParam);
            case "Fire":
                return new FireBender(benderName, benderPower, benderAuxParam);
            case "Water":
                return new WaterBender(benderName, benderPower, benderAuxParam);
            case "Earth":
                return new EarthBender(benderName, benderPower, benderAuxParam);
            default:
                throw new ArgumentException();
        }
    }

    private Monument GetMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];
        var monumentName = monumentArgs[1];
        var monumentAffinity = int.Parse(monumentArgs[2]);

        switch (monumentType)
        {
            case "Fire":
                return new FireMonument(monumentName, monumentAffinity);
            case "Water":
                return new WaterMonument(monumentName, monumentAffinity);
            case "Air":
                return new AirMonument(monumentName, monumentAffinity);
            case "Earth":
                return new EarthMonument(monumentName, monumentAffinity);
            default:
                throw new ArgumentException();
        }
    }
}
