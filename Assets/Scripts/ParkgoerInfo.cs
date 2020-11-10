using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkgoerInfo
{
    private string name;
    private static string[] names = {"Chris","Becca","Kyler","Emily","Libby","Kirby"};

    public ParkgoerInfo() {
        GenerateName();
    }

    private void GenerateName() {
        int res = Random.Range(0, names.Length);
        name = names[res];
    }

    public string GetName() {
        return name;
    }
}
