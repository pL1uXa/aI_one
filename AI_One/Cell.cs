using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace AI_One
{
    class Cell
    {
        private int counter; // Итерация
        private int age; // Возраст
        public int energy; // Энергия
        private int dir; // Направление
        public int[] genes; // Набор генов
        public Point pos; // Координаты (текущие)
        private int mutation; // Счетчик до мутации
        public Color color; // Цвет клетки

        public Cell(int[,] map, int[] _genes, Point _pos)
        {
            //id = counter_id++;
            counter = 0; // Первая итерация
            age = 0; // Начальный возраст
            dir = 0; // Начальное направление
            energy = Constants.energy_start; // Начальная энергия
            genes = new int[Constants.gen_count]; // Набор генов
            if (_genes != null) _genes.CopyTo(genes, 0); // Унаследуем набор генов при делении
            pos = _pos; // Начальная позиция
            mutation = 0; // Потомства еще нет
            color = Color.FromArgb(Constants.rand.Next(255), Constants.rand.Next(255), Constants.rand.Next(255));
        }
        public static void first_generation(int[,] map, List<Cell> cell) // Первое поколение
        {
            for (int i = 0; i < Constants.size_first_gen; i++)
            {
                cell.Add(new Cell(map, null, new Point(-1, -1)));
            }

            for (int j = 0; j < Constants.size_first_gen; j++)
            {
                for (int i = 0; i < Constants.gen_count; i++)
                {
                    cell[j].genes[i] = Constants.rand.Next(Constants.gen_max); // Начальные гены
                }

                while (cell[j].pos.X == -1 && cell[j].pos.Y == -1) // Начальная позиция
                {
                    int x = Constants.rand.Next(Map.size_map);
                    int y = Constants.rand.Next(Map.size_map);

                    if (map[x, y] == Constants.map_void)
                    {
                        cell[j].pos.X = x;
                        cell[j].pos.Y = y;
                        map[cell[j].pos.X, cell[j].pos.Y] = Constants.map_cell;
                    }
                }
            }
        }
        private Point direction(int _dir, Point n_pos) // Выбираем направление
        {
            switch (_dir)
            {
                case 0:
                    {
                        n_pos.X = pos.X + 1;
                        n_pos.Y = pos.Y - 1;
                        break;
                    }
                case 1:
                    {
                        n_pos.X = pos.X + 1;
                        n_pos.Y = pos.Y;
                        break;
                    }
                case 2:
                    {
                        n_pos.X = pos.X + 1;
                        n_pos.Y = pos.Y + 1;
                        break;
                    }
                case 3:
                    {
                        n_pos.X = pos.X;
                        n_pos.Y = pos.Y + 1;
                        break;
                    }
                case 4:
                    {
                        n_pos.X = pos.X - 1;
                        n_pos.Y = pos.Y + 1;
                        break;
                    }
                case 5:
                    {
                        n_pos.X = pos.X - 1;
                        n_pos.Y = pos.Y;
                        break;
                    }
                case 6:
                    {
                        n_pos.X = pos.X - 1;
                        n_pos.Y = pos.Y - 1;
                        break;
                    }
                case 7:
                    {
                        n_pos.X = pos.X;
                        n_pos.Y = pos.Y - 1;
                        break;
                    }
            }

            // Замыкаем карту со всех сторон
            if (n_pos.X == -1) n_pos.X = Map.size_map - 1;
            if (n_pos.Y == -1) n_pos.Y = Map.size_map - 1;
            if (n_pos.X == Map.size_map) n_pos.X = 0;
            if (n_pos.Y == Map.size_map) n_pos.Y = 0;

            return n_pos;
        }
        private void set_pos(Point n_pos) // Устанавливаем новую позицию
        {
            pos = n_pos;
        }
        private int check_counter(int gen) // Исправляем счетчик
        {
            if (counter + gen < Constants.gen_count) return counter += gen;
            else return counter += gen - Constants.gen_count;
        }
        public string get_info(int num) // Возвращаем информацию о клетке
        {
            string s = "";
            if (num == 1)
            {
                s += "Возраст: " + age + "\n";
                s += "Энергия: " + energy + "\n";
                s += "Координаты: " + pos.X + ":" + pos.Y + "\n\n";
                s += "Набор генов:";
                for (int i = 0; i < Constants.gen_count; i++)
                {
                    if (i % 8 == 0) s += "\n";
                    if (i == counter) s += "[" + genes[i] + "] ";
                    else s += genes[i] + "  ";
                }
            }
            else if (num == 2)
            {
                for (int i = 0; i < Constants.gen_count; i++)
                {
                    s += genes[i];
                    if (i < Constants.gen_count - 1) s += ", ";
                }
            }

            return s;
        }
        private bool working(int[,] map) // Работа генов
        {
            if (energy <= Constants.energy_dead) // Смерть клетки
            {
                map[pos.X, pos.Y] = Constants.map_void;
                return false;
            }

            int step = 0;

            while (step < Constants.gen_step)
            {
                check_counter(0); // Исправляем счетчик

                if (genes[counter] < Constants.gen_moving) // Движение
                {
                    Point n_pos = new Point(0, 0); // Координаты (новые)
                    int check = -99;

                    dir = genes[check_counter(0)] % 8; // Выбираем направление
                    n_pos = direction(dir, n_pos); // Меняем направление

                    if (map[n_pos.X, n_pos.Y] == Constants.map_void)
                    {
                        map[pos.X, pos.Y] = Constants.map_void;
                        map[n_pos.X, n_pos.Y] = Constants.map_cell;
                        set_pos(n_pos); // Обновляем текущую позицию
                        check = 2;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_cell)
                    {
                        check = 3;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_eat)
                    {
                        map[pos.X, pos.Y] = Constants.map_void;
                        map[n_pos.X, n_pos.Y] = Constants.map_cell;
                        set_pos(n_pos); // Обновляем текущую позицию
                        energy += Constants.energy_eat; // Добавляем энергию
                        if (energy > Constants.energy_max) energy = Constants.energy_max; // Макс энергия
                        check = 4;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_block)
                    {
                        check = 5;
                    }

                    counter += genes[check_counter(check)]; // Смещение счетчика
                    break; // Завершаем шаг
                }

                else if (genes[counter] < Constants.gen_eat) // Еда
                {
                    Point n_pos = new Point(0, 0); // Координаты (новые)
                    int check = -99;

                    dir = genes[check_counter(0)] % 8; // Выбираем направление
                    n_pos = direction(dir, n_pos); // Меняем направление

                    if (map[n_pos.X, n_pos.Y] == Constants.map_void)
                    {
                        check = 2;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_cell)
                    {
                        check = 3;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_eat)
                    {
                        map[n_pos.X, n_pos.Y] = Constants.map_void;
                        energy += Constants.energy_eat; // Добавляем энергию
                        if (energy > Constants.energy_max) energy = Constants.energy_max; // Макс энергия
                        check = 4;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_block)
                    {
                        check = 5;
                    }

                    counter += genes[check_counter(check)]; // Смещение счетчика
                    break; // Завершаем шаг
                }

                else if (genes[counter] < Constants.gen_eye) // Посмотреть
                {
                    Point n_pos = new Point(0, 0); // Координаты (новые)
                    int check = -99;

                    dir = genes[check_counter(1)] % 8; // Выбираем направление
                    n_pos = direction(dir, n_pos); // Меняем направление

                    if (map[n_pos.X, n_pos.Y] == Constants.map_void)
                    {
                        check = 2;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_cell)
                    {
                        check = 3;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_eat)
                    {
                        check = 4;
                    }
                    else if (map[n_pos.X, n_pos.Y] == Constants.map_block)
                    {
                        check = 5;
                    }

                    counter += genes[check_counter(check)]; // Смещение счетчика
                    step++; // Увеличиваем счетчик шагов
                }

                else if (genes[counter] < Constants.gen_rotation) // Поворот
                {
                    dir = genes[check_counter(1)] % 8; // Выбираем направление
                    check_counter(1);
                    step++; // Увеличиваем счетчик шагов
                }

                else if (genes[counter] < Constants.gen_max) // Безусловный переход
                {
                    counter += genes[counter];
                    step++; // Увеличиваем счетчик шагов
                }
            }

            age++; // Добавляяем шаг к возрасту
            energy -= Constants.energy_consumption; // Забираем энергию
            return true;
        }
        public static void update(int[,] map, List<Cell> cell) // Обновляем клетку
        {
            for (int i = 0; i < cell.Count; i++)
            {
                if (!cell[i].working(map)) cell.RemoveAt(i--);
            }
        }
        public static void draw(List<Cell> cell, Graphics g) // Обновляем клетку
        {
            for (int i = 0; i < cell.Count; i++)
            {
                g.FillRectangle(new SolidBrush(cell[i].color), cell[i].pos.X * Map.pixel, cell[i].pos.Y * Map.pixel, Map.pixel, Map.pixel);
            }
        }
        public static void division(List<Cell> cell, int[,] map) // Деление клетки (создание новой клетки)
        {
            for (int i = 0; i < cell.Count; i++)
            {
                if (cell[i].energy >= Constants.energy_max - Constants.energy_consumption)
                {
                    Point n_pos = new Point(0, 0); // Координаты (новые)

                    for (int j = 0; j < 8; j++)
                    {
                        n_pos = cell[i].direction(j, n_pos); // Меняем направление
                        if (map[n_pos.X, n_pos.Y] == Constants.map_void)
                        {
                            int[] _genes = new int[Constants.gen_count];
                            _genes = cell[i].genes;
                            if (cell[i].mutation == Constants.mutation) // Меняем случайный ген
                            {
                                int f1 = Constants.rand.Next(Constants.gen_count);
                                int f2 = Constants.rand.Next(Constants.gen_max);
                                _genes[f1] = f2;
                                cell[i].mutation = 0;
                            }
                            else cell[i].mutation++;

                            cell.Add(new Cell(map, _genes, n_pos));
                            map[n_pos.X, n_pos.Y] = Constants.map_cell;
                            break; // Поделились и выходим
                        }
                    }
                }
            }
        }
    }
}
