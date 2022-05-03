using UnityEngine;

public static class ScreenPositionTools
{
    public static Vector3 RandomScreenLocation()
    {
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);

        return new Vector3(randomX, randomY, 10);
    }

    public static Vector3 RandomWorldLocation()
    {
        Vector3 randomScreenLocation = RandomScreenLocation();
        return Camera.main.ScreenToWorldPoint(randomScreenLocation);
    }

    public static Vector3 RandomTopOfScreenLocation()
    {
        float randomX = Random.Range(0, Screen.width);
        return new Vector3(randomX, Screen.height, 10);
    }

    public static Vector3 RandomTopOfScreenWorldLocation()
    {
        Vector3 randomTopOfScreenLocation = RandomTopOfScreenLocation();
        return Camera.main.ScreenToWorldPoint(randomTopOfScreenLocation);
    }

    public static Vector3 RandomOffScreenWorldLocation()
    {
        Vector3 position;
        switch (RandomSide())
        {
            case 1: // right
                position = new Vector3(Screen.width + 50, Random.Range(0, Screen.height), 10);
                break;
            case 2: // left
                position = new Vector3(-50, Random.Range(0, Screen.height), 10);
                break;
            case 3: // top
                position = new Vector3(Random.Range(0, Screen.width), Screen.height + 50, 10);
                break;
            case 4: // bottom
                position = new Vector3(Random.Range(0, Screen.width), -50, 10);
                break;
            default:
                position = new Vector3(Random.Range(0, Screen.width), Screen.height + 50, 10);
                break;
        }
        return Camera.main.ScreenToWorldPoint(position);
    }

    private static int RandomSide()
    {
        // 1 = right, 2 = left, 3 = top, 4 = bottom
        return Random.Range(1, 4);
    }
}