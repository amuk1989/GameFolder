using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject CanvasHealth; // ������ �� ������ Canvas, ���������� Health Bar
    public Image Bar; // ������ �� UI Image, �������������� ������ ��������

    void Update()
    {
        // ����� LookAt() ��������� Health Bar ������ �������� �� �������� ������
        // ����� ������������ ������ Camera.main, ������� ��������� �� ������� ������ � �����
        CanvasHealth.transform.LookAt(Camera.main.transform);

        // ������� Health Bar �� ��� Z, ����� �� ������ ��������� ������������ ��������� ������
        // ��� ��������� Health Bar ������ �������� �� ������ ���������� �� ���� ������
        CanvasHealth.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    // ������� ��� ���������� ������ �������� � Health Bar
    // ��������� ������������ � ������� �������� � ���� ����� �����
    
    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        // ���������� �������� �������� �������� �� �������������
        float healthPercentage = (float)currentHealth / maxHealth;

        // ���������� �������� fillAmount � UI Image Bar, ������� ������������ ������ ��������
        Bar.fillAmount = healthPercentage;
    }
}