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

        static public List<Point> UpdateSimulation()
        {
            CellsToRedraw = new List<Point>();

            MoveAnimals();

            return CellsToRedraw;

            //TODO Переработать логику типов растений и изменить метод размножения растений
            /*List<SimulationObject> plants = Map.SimulationObjects.Where(unit => unit is Plant).ToList();
            for (int i = 1; i < amountCells; i++)
            {
                if (cells[i].fullness != 0)
                {
                    switch (cells[i].fullness)
                    {
                        case 1:
                            stepPlant = plantInfertileEdible[i].Step();
                            if (stepPlant == CellState.Function)
                                plantInfertileEdible[i].Mechanochoria(cells, plantInfertileEdible, amountCellsX, amountCellsY);
                            break;
                        case 2:
                            stepPlant = plantFruitingEdible[i].Step();
                            if (stepPlant == CellState.Function)
                            {
                                cells[i].fruit = true;
                                plantFruitingEdible[i].Mechanochoria(cells, plantFruitingEdible, amountCellsX, amountCellsY);
                                plantFruitingEdible[i].Fruiting(fruits[i]);
                            }
                            break;
                        case 3:
                            stepPlant = plantInfertilePoisonous[i].Step();
                            if (stepPlant == CellState.Function)
                                plantInfertilePoisonous[i].Mechanochoria(cells, plantInfertilePoisonous, amountCellsX, amountCellsY);
                            break;
                        case 4:
                            stepPlant = plantFruitingPoisonous[i].Step();
                            if (stepPlant == CellState.Function)
                            {
                                cells[i].fruit = true;
                                plantFruitingPoisonous[i].Mechanochoria(cells, plantFruitingPoisonous, amountCellsX, amountCellsY);
                                plantFruitingPoisonous[i].Fruiting(fruits[i]);
                            }
                            break;
                        case 7:
                            stepPlant = plantInfertileInEdible[i].Step();
                            if (stepPlant == CellState.Function)
                                plantInfertileInEdible[i].Mechanochoria(cells, plantInfertileInEdible, amountCellsX, amountCellsY);
                            break;
                        case 8:
                            stepPlant = plantFruitingInEdible[i].Step();
                            if (stepPlant == CellState.Function)
                            {
                                cells[i].fruit = true;
                                plantFruitingInEdible[i].Mechanochoria(cells, plantFruitingInEdible, amountCellsX, amountCellsY);
                                plantFruitingInEdible[i].Fruiting(fruits[i]);
                            }
                            break;
                        default:
                            break;
                    }
                    if (stepPlant == CellState.Sprout)
                        cells[i].plantSeed = false;
                    else if (stepPlant == CellState.Empty)
                        cells[i].fullness = 0;
                    stepPlant = CellState.Empty;
                }

                if (cells[i].fruit)
                {
                    fruits[i].Update();
                    if (fruits[i].state == FruitState.Empty)
                        cells[i].fruit = false;
                }
            }*/
        }
    }
}
