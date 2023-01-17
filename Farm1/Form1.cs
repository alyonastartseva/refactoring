using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm1
{
    public partial class Form1 : Form
    {
        Dictionary<int, Animal> animal = new Dictionary<int, Animal>();
        Dictionary<int, Plant> plant = new Dictionary<int, Plant>(); //Edit same Animal
        Dictionary<int, FruitingPoisonousPlant> plantFruitingPoisonous = new Dictionary<int, FruitingPoisonousPlant>();
        Dictionary<int, FruitingEdiblePlant> plantFruitingEdible = new Dictionary<int, FruitingEdiblePlant>();
        Dictionary<int, FruitingInEdiblePlant> plantFruitingInEdible = new Dictionary<int, FruitingInEdiblePlant>();
        Dictionary<int, InfertilePoisonousPlant> plantInfertilePoisonous = new Dictionary<int, InfertilePoisonousPlant>();
        Dictionary<int, InfertileEdiblePlant> plantInfertileEdible = new Dictionary<int, InfertileEdiblePlant>();
        Dictionary<int, InfertileInEdiblePlant> plantInfertileInEdible = new Dictionary<int, InfertileInEdiblePlant>();
        Dictionary<int, Fruit> fruits = new Dictionary<int, Fruit>();
        Dictionary<int, Cell> cells = new Dictionary<int, Cell>();
        // Add and edit new plant classes plus logic cell Dictionary plus fruit or new Dictionary fruit

        //Edit Accesses with this and all classes
        public Random rnd = new Random();
        public Bitmap generalBitmap;
        public Graphics graphics;
        public Brush color;
        public int elementalAmountAllKindPlants = 10000;
        public int amountPlants = 6000;
        public int amountAnimals = 1000;
        public int amountCellsX = 1000;
        public int amountCellsY = 1000;
        public int amountCells;
        public int sizeCell = 9;
        public int sizeCellPlus;
        public int maxX;
        public int maxY;
        public int diedPlants = 0; //Maybe delete?
        public int diedAnimals = 0;
        public int random = 0;
        public int date = 0;
        public int step = 0;
        CellState stepPlant = CellState.Empty;
        public bool eat = false;


        public Form1()
        {
            InitializeComponent();

            sizeCellPlus = sizeCell + 1;
            amountCells = amountCellsX * amountCellsY;
            maxX = amountCellsX * sizeCellPlus + 1;
            maxY = amountCellsY * sizeCellPlus + 1;


            generalBitmap = new Bitmap(amountCellsX * sizeCellPlus + 11, amountCellsY * sizeCellPlus + 11);
            pictureBox1.Size = generalBitmap.Size;
            pictureBox1.Image = generalBitmap;
            graphics = Graphics.FromImage(pictureBox1.Image);

            // Edit logic how Plant Dictionary not giving map
            for (int i = 1; i <= amountCells; i++)
            {
                //plant.Add(i, new Plant());
                cells.Add(i, new Cell(i % amountCellsX, i / amountCellsX));
                plantFruitingPoisonous.Add(i, new FruitingPoisonousPlant(i % amountCellsX, i / amountCellsX));
                plantFruitingEdible.Add(i, new FruitingEdiblePlant(i % amountCellsX, i / amountCellsX));
                plantFruitingInEdible.Add(i, new FruitingInEdiblePlant(i % amountCellsX, i / amountCellsX));
                plantInfertilePoisonous.Add(i, new InfertilePoisonousPlant(i % amountCellsX, i / amountCellsX));
                plantInfertileEdible.Add(i, new InfertileEdiblePlant(i % amountCellsX, i / amountCellsX));
                plantInfertileInEdible.Add(i, new InfertileInEdiblePlant(i % amountCellsX, i / amountCellsX));
                fruits.Add(i, new Fruit());
            }
            for (int i = 1; i <= elementalAmountAllKindPlants; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                plantFruitingPoisonous[random].existence = true;
                cells[random].plantSeed = true;
                cells[random].fullness = 4;
            }
            for (int i = 1; i <= elementalAmountAllKindPlants; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                plantFruitingEdible[random].existence = true;
                cells[random].plantSeed = true;
                cells[random].fullness = 2;
            }
            for (int i = 1; i <= elementalAmountAllKindPlants; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                plantFruitingInEdible[random].existence = true;
                cells[random].plantSeed = true;
                cells[random].fullness = 8;
            }
            for (int i = 1; i <= elementalAmountAllKindPlants; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                plantInfertilePoisonous[random].existence = true;
                cells[random].plantSeed = true;
                cells[random].fullness = 3;
            }
            for (int i = 1; i <= elementalAmountAllKindPlants; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                plantInfertileEdible[random].existence = true;
                cells[random].plantSeed = true;
                cells[random].fullness = 1;
            }
            for (int i = 1; i <= elementalAmountAllKindPlants; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                plantInfertileInEdible[random].existence = true;
                cells[random].plantSeed = true;
                cells[random].fullness = 7;
            }

            
            for (int i = 1; i <= amountAnimals; i++)
            {
                random = rnd.Next(1, amountCells);
                while (cells[random].fullness != 0)
                {
                    random = rnd.Next(1, amountCells);
                }
                animal.Add(i, new Animal());
                cells[i].fullness = 9;
                animal[i].x = random % amountCellsX;
                animal[i].y = random / amountCellsX;
            }

            Painting();
        }

        private void Painting()
        {
            //Clean traces
            graphics.FillRectangle(Brushes.White, 1, 1, maxX, maxY);

            //Painting lines
            for (int i = 0; i <= amountCellsX; i++)
                graphics.DrawLine(Pens.Black, 1, i * sizeCellPlus + 1, maxX, i * sizeCellPlus + 1);
            for (int i = 0; i <= amountCellsY; i++)
                graphics.DrawLine(Pens.Black, i * sizeCellPlus + 1, 1, i * sizeCellPlus + 1, maxY);

            //Изменить логику отрисовки фрукта
            for (int i = 1; i <= amountCells; i++)
            {
                switch(cells[i].fullness)
                {
                    case 1:
                        PaintingPlant(i, plantInfertileEdible[i].state);
                        break;
                    case 2:
                        PaintingPlant(i, plantFruitingEdible[i].state);
                        break;
                    case 3:
                        PaintingPlant(i, plantInfertilePoisonous[i].state);
                        PaintingPoisonous(i);
                        break;
                    case 4:
                        PaintingPlant(i, plantFruitingPoisonous[i].state);
                        PaintingPoisonous(i);
                        break;
                    case 7:
                        PaintingPlant(i, plantInfertileInEdible[i].state);
                        PaintingInEdible(i);
                        break;
                    case 8:
                        PaintingPlant(i, plantFruitingInEdible[i].state);
                        PaintingInEdible(i);
                        break;
                    default:
                        break;
                }
                if (cells[i].fruit)
                {
                    PaintingFruiting(i, fruits[i].state, fruits[i].poison);
                }
            }

            for (int i = 1; i <= amountAnimals; i++)
            {
                if (animal[i].existence)
                    graphics.FillRectangle(Brushes.Red, animal[i].x * sizeCellPlus + 2, animal[i].y * sizeCellPlus + 2, sizeCell, sizeCell);
            }
        }

        private void PaintingPoisonous(int i)
        {
            graphics.FillRectangle(Brushes.Magenta, (i % amountCellsX) * sizeCellPlus + 5, (i / amountCellsX) * sizeCellPlus + 5, 3, 3);
        }

        private void PaintingInEdible(int i)
        {
            graphics.FillRectangle(Brushes.Black, (i % amountCellsX) * sizeCellPlus + 5, (i / amountCellsX) * sizeCellPlus + 5, 3, 3);
        }

        private void PaintingFruiting(int i, FruitState state, bool poison)
        {
            switch(state)
            {
                case FruitState.Immature:
                    color = Brushes.Blue;
                    break;
                case FruitState.Medium:
                    color = Brushes.BlueViolet;
                    break;
                case FruitState.Done:
                    if (poison)
                        color = Brushes.Magenta;
                    else
                        color = Brushes.Red;
                    break;
                case FruitState.Rotten:
                    color = Brushes.Chocolate;
                    break;
                default:
                    color = Brushes.White;
                    break;
            }
            graphics.FillRectangle(color, (i % amountCellsX) * sizeCellPlus + 8, (i / amountCellsX) * sizeCellPlus + 2, 3, 3);
        }

        private void PaintingPlant(int i, CellState state)
        {
            switch(state)
            {
                case CellState.Seed:
                    color = Brushes.Yellow;
                    break;
                case CellState.Sprout:
                    color = Brushes.GreenYellow;
                    break;
                case CellState.Green:
                    color = Brushes.Lime;
                    break;
                case CellState.Function:
                    color = Brushes.Green;
                    break;
                case CellState.Rotten:
                    color = Brushes.Chocolate;
                    break;
                default:
                    color = Brushes.DeepPink;
                    break;
            }
            graphics.FillRectangle(color, (i % amountCellsX) * sizeCellPlus + 2, (i / amountCellsX) * sizeCellPlus + 2, sizeCell, sizeCell);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date++;
            label1.Text = "Day: " + date;
            label2.Text = "Animals: " + (amountAnimals - diedAnimals);
            label4.Text = "Plants: " + (amountPlants - 0); //Edit when we have more than one Plant Class
            diedAnimals = 0;

            

            //Realize another Animal Step logic
            for (int i = 1; i <= amountAnimals; i++)
            {
                if (animal[i].existence)
                {
                    step = animal[i].Step(cells); //Edit this moment with new logic
                    if ((cells[step].fruit) && (fruits[step].poison))
                    {
                        animal[i].Eat(-10);
                        cells[step].fruit = false;
                    }
                    if ((cells[step].fruit) && !(fruits[step].poison))
                    {
                        animal[i].Eat(-10);
                        cells[step].fruit = false;
                    }
                    if ((cells[step].fullness > 0) && (cells[step].fullness <= 2) && !(cells[i].plantSeed))
                    {
                        animal[i].Eat(10);
                        plantFruitingPoisonous[step].Die();
                        plantFruitingEdible[step].Die();
                        plantFruitingInEdible[step].Die();
                        plantInfertilePoisonous[step].Die();
                        plantInfertileEdible[step].Die();
                        plantInfertileInEdible[step].Die();
                        cells[step].fullness = 0;
                    }
                    if ((cells[step].fullness > 2) && (cells[step].fullness <= 4) && !(cells[i].plantSeed))
                    {
                        animal[i].Eat(-10);
                        plantFruitingPoisonous[step].Die();
                        plantFruitingEdible[step].Die();
                        plantFruitingInEdible[step].Die();
                        plantInfertilePoisonous[step].Die();
                        plantInfertileEdible[step].Die();
                        plantInfertileInEdible[step].Die();
                        cells[step].fullness = 0;
                    }
                    
                }
                else
                    diedAnimals++;
            }

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
            }



            

            if (date % 1 == 0)
            {
                pictureBox1.Refresh();
                Painting();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = 101 - (int)numericUpDown1.Value;
            timer1.Interval = r;
        }

    }


}
