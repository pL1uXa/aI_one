using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AI_One
{
    class Map
    {
        public const int size_paint = 400; // Размер изображения
        public const int size_map = size_paint / pixel; // Размер карты
        public const int pixel = 2; // Размер пикселя
        public static int food = 0; // Еды на поле
        public static int up_step = 0; // Текущий шаг обновления
        public static int[,] map = new int[size_map, size_map]; // Карта

        public static void create_map() // Создание карты
        {
            for (int i = 0; i < size_map; i++)
                for (int j = 0; j < size_map; j++)
                    map[i, j] = Constants.map_void;
            for (int i = 6; i < 16; i++) map[i, 30] = Constants.map_block;
            for (int i = 13; i < 38; i++) map[i, 13] = Constants.map_block;
            for (int i = 28; i < 39; i++) map[16, i] = Constants.map_block;
        }
        private static void update_food(int cell_count) // Разбрасываем еду по карте
        {
            while (food < Constants.food_max && (cell_count + food) < (size_map * size_map))
            {
                int x = Constants.rand.Next(size_map);
                int y = Constants.rand.Next(size_map);

                if (map[x, y] == Constants.map_void)
                {
                    map[x, y] = Constants.map_eat;
                    food++;
                }
            }
            food = 0;
        }
        public static void update_map(Panel p, List<Cell> cell) // Перерисовка карты
        {
            update_food(cell.Count); // Разбрасываем еду по карте
            up_step++; // Увеличиваем шаг обновления
            
            if (up_step == Constants.update_step)
            {
                Bitmap bmp = new Bitmap(size_paint, size_paint);
                Graphics g = Graphics.FromImage(bmp);

                for (int i = 0; i < size_map; i++)
                    for (int j = 0; j < size_map; j++)
                    {
                        if (map[i, j] != Constants.map_cell) // Если не клетка
                        {
                            if (map[i, j] == Constants.map_void) // Пусто
                            {
                                g.FillRectangle(Brushes.White, i * pixel, j * pixel, pixel, pixel);
                            }
                            else if (map[i, j] == Constants.map_eat) // Еда
                            {
                                g.FillRectangle(Brushes.Khaki, i * pixel, j * pixel, pixel, pixel);
                                food++;
                            }
                            else if (map[i, j] == Constants.map_block) // Стена
                            {
                                g.FillRectangle(Brushes.Black, i * pixel, j * pixel, pixel, pixel);
                            }
                        }
                    }

                Cell.draw(cell, g); // Рисуем клетки отдельно

                p.BackgroundImage = bmp;

                up_step = 0; // Сбрасываем шаг обновления
            }
            else
            {
                for (int i = 0; i < size_map; i++)
                    for (int j = 0; j < size_map; j++)
                        if (map[i, j] == Constants.map_eat) food++;
            }
        }
        public static int get_index_cell(List<Cell> cell, MouseEventArgs e) //Индекс клетки
        {
            if (cell.Exists(x => x.pos.X == e.X / pixel && x.pos.Y == e.Y / pixel))
                return cell.FindIndex(x => x.pos.X == e.X / pixel && x.pos.Y == e.Y / pixel);
            else
                return -99;
        }
    }
}
