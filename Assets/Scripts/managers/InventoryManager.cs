using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : AbstractSnapTarget
{

    private static readonly Logger LOG = new Logger(typeof(InventoryManager));

    private List<Vector2> gridCenterPoints = new List<Vector2>();
    void Awake()
    {
        float topLeftX = transform.position.x - 1.5f;
        float topLeftY = transform.position.y + 2f;
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                Vector2 gridCenterPoint = new Vector2(topLeftX + x, topLeftY - y);
                gridCenterPoints.Add(gridCenterPoint);
            }
        }
    }

    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
    }

    public void addDice(Dice dice)
    {
        Vector2 pos = gridCenterPoints[dice.id];
        dice.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void GetDices()
    {

    }

    public override List<Vector2> GetGridCenterPoints()
    {
        return gridCenterPoints;
    }

    public override bool Accept(System.Type type)
    {
        return type.IsAssignableFrom(typeof(TestSquareGroup));
    }

}
