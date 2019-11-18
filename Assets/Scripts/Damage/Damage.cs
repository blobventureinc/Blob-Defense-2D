using System.Collections;
using System.Collections.Generic;

public struct Damage {
    public int _physicalDmg;
    public int _poisonDmg;
    public int _fireDmg;
    public int _waterDmg;
    public int _windDmg;
    public int _earthDmg;
    public int _shadowDmg;
    public int _lightDmg;

    public Damage(int physicalDmg, int poisonDmg, int fireDmg, int waterDmg, int windDmg, int earthDmg, int shadowDmg, int lightDmg) {
        _physicalDmg = physicalDmg;
        _poisonDmg = poisonDmg;
        _fireDmg = fireDmg;
        _waterDmg = waterDmg;
        _windDmg = windDmg;
        _earthDmg = earthDmg;
        _shadowDmg = shadowDmg;
        _lightDmg = lightDmg;
    }
}