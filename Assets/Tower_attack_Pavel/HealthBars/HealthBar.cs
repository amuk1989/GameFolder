using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject CanvasHealth; // Ссылка на объект Canvas, содержащий Health Bar
    public Image Bar; // Ссылка на UI Image, представляющий полосу здоровья

    void Update()
    {
        // Метод LookAt() позволяет Health Bar всегда смотреть на основную камеру
        // Здесь используется камера Camera.main, которая ссылается на главную камеру в сцене
        CanvasHealth.transform.LookAt(Camera.main.transform);

        // Поворот Health Bar по оси Z, чтобы он всегда оставался параллельным плоскости экрана
        // Это позволяет Health Bar всегда смотреть на игрока независимо от угла камеры
        CanvasHealth.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    // Функция для обновления полосы здоровья в Health Bar
    // Принимает максимальное и текущее здоровье в виде целых чисел
    
    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        // Вычисление процента текущего здоровья от максимального
        float healthPercentage = (float)currentHealth / maxHealth;

        // Обновление значения fillAmount в UI Image Bar, которая представляет полосу здоровья
        Bar.fillAmount = healthPercentage;
    }
}