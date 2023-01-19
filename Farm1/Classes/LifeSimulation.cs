using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Farm1.Classes
{
    static class LifeSimulation
    {
        static private List<Point> CellsToRedraw = new List<Point>();

        static public List<Point> InitializeLifeSimulation()
        {
            Map.SimulationObjects = new List<SimulationObject>();
            Map.Area = new List<Cell>();

            for (int i = 0; i < Map.Width; ++i)
            {
                for (int j = 0; j < Map.Height; ++j)
                {
                    Map.Area.Add(new Cell(j, i));
                }
            }

            InitializeObjects();
            return CellsToRedraw;
        }

        static private void InitializeObjects()
        {
            InitializeObjects<InfertileEdiblePlant>(Map.elementalAmountAllKindPlants);
            InitializeObjects<InfertileInEdiblePlant>(Map.elementalAmountAllKindPlants);
            InitializeObjects<InfertilePoisonousPlant>(Map.elementalAmountAllKindPlants);

            InitializeObjects<FruitingEdiblePlant>(Map.elementalAmountAllKindPlants);
            InitializeObjects<FruitingPoisonousPlant>(Map.elementalAmountAllKindPlants);
            InitializeObjects<FruitingInEdiblePlant>(Map.elementalAmountAllKindPlants);

            InitializeObjects<Fruit>(Map.elementalAmountAllKindPlants);
            InitializeObjects<Animal>(Map.elementalAmountAllKindPlants);
        }

        static private void InitializeObjects<TType>(int amountOfObjects)
            where TType : SimulationObject, new()
        {
            int initNumOfObjects = Map.Random.Next(1, amountOfObjects);

            for (int i = 0; i < initNumOfObjects; ++i)
            {
                var newObject = new TType();

                Map.SimulationObjects.Add(newObject);
                Map.Area[newObject.Coordinates.Y * Map.Width + newObject.Coordinates.X].Objects.Add(newObject);

                CellsToRedraw.Add(newObject.Coordinates);
            }
        }

        static private void MoveAnimals()
        {
            List<SimulationObject> animals = Map.SimulationObjects.Where(unit => unit is Animal).ToList();

            for (int i = animals.Count - 1; i >= 0; --i)
            {
                CellsToRedraw.Add(animals[i].Coordinates);
                Map.Area[animals[i].Coordinates.Y * Map.Width + animals[i].Coordinates.X].Objects.Remove(animals[i]);

                if (animals[i].IsAlive)
                {
                    CellsToRedraw.Add(((Animal)animals[i]).Step());
                }

            }
        }

        static private void GrowPlants<TType>()
           where TType : Plant, new()
        {
            List<SimulationObject> plants = Map.SimulationObjects.Where(unit => unit is Plant).ToList();

            for (int i = 0; i < plants.Count - 1; ++i)
            {
                Point randomPoint = new Point();

                Plant randomPlant = (Plant)plants[Map.Random.Next(plants.Count)];

                randomPoint.X = Math.Max(Math.Min(randomPlant.Coordinates.X + Map.Random.Next(2) - 1, Map.Height - 1), 0);
                randomPoint.Y = Math.Max(Math.Min(randomPlant.Coordinates.Y + Map.Random.Next(2) - 1, Map.Height - 1), 0);

                var newObject = new TType();
                newObject.Coordinates = randomPoint;

                Map.SimulationObjects.Add(newObject);
                Map.Area[newObject.Coordinates.Y * Map.Width + newObject.Coordinates.X].Objects.Add(newObject);

                CellsToRedraw.Add(newObject.Coordinates);

                CellsToRedraw.Add(((Plant)plants[i]).Step());
            }
        }

        static private void GrowPlants()
        {
            GrowPlants<FruitingEdiblePlant>();
            GrowPlants<FruitingInEdiblePlant>();
            GrowPlants<FruitingPoisonousPlant>();
            GrowPlants<InfertileEdiblePlant>();
            GrowPlants<InfertileInEdiblePlant>();
            GrowPlants<InfertilePoisonousPlant>();
        }

        static public List<Point> UpdateSimulation()
        {
            CellsToRedraw = new List<Point>();

            MoveAnimals();
            GrowPlants();

            return CellsToRedraw;
        }
    }
}
