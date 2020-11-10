using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkgoerInfo
{
    private string name;
    private static string[] names = {"Chris","Becca","Kyler","Emily","Libby","Kirby"};

    private int age = 0;

    private float happiness = 0.0f;
    private float energy = 1.0f;
    private float maxSpd = 5f;

    public ParkgoerInfo() {
        AssignRandomName();
        AssignRandomAge();
        AssignRandomMaxSpeed();
    }

    private void AssignRandomName() {
        int res = Random.Range(0, names.Length);
        name = names[res];
    }

    private void AssignRandomAge() {
        int res = Random.Range(0, 100);
        age = res;
    }

    private void AssignRandomMaxSpeed() {
        float res = Random.Range(50, 100);
        maxSpd = res / 10f;
    }

    public string GetName() {
        return name;
    }

    public int GetAge() {
        return age;
    }

    public float GetMaxSpeed() {
        return maxSpd;
    }
}
