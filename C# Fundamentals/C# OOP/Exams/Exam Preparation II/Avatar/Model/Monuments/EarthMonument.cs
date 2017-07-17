﻿using System.Text;

public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity
    {
        get { return this.earthAffinity; }
        private set { this.earthAffinity = value; }
    }

    public override string ToString()
    {
        return $"###Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}";
    }

    public override int MonumentBonus()
    {
        return this.EarthAffinity;
    }
}
